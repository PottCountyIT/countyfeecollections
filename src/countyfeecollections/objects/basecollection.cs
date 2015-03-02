//---------------------------------------------------------------------
//  Copyright (C) Microsoft Corporation.  All rights reserved.
// 
//THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
//KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//PARTICULAR PURPOSE.
//---------------------------------------------------------------------

/*
 * 
 * This class has been heavily modified from its original version in order to work as a base class in
 * this application.
 * 
 * Contractor
 * 3/13/2009
 * 
 */


using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Reflection;
using System.Collections;
using System.Runtime.CompilerServices;

namespace county.feecollections
{



    
    public class BaseCollection<T> : BindingList<T>, IBindingListView where T : BaseObject, new()
    {

        private int _intParentId = -1;
        private List<T> _lstOriginalList = new List<T>();
        private List<T> _lstRemovedObjects = new List<T>();
        private string _strFilter = null;
        private bool _isLoading;
        private DateTime _UpdateDate;
        private PropertyComparerCollection<T> _sorts;

        #region public int ParentId
        /// <summary>
        /// Gets or set an id of the parent object.
        /// </summary>
        public int ParentId
        {
            get { return _intParentId; }
            set { _intParentId = value; }
        } 
        #endregion

        #region public List<T> OriginalList
        public List<T> OriginalList
        {
            get { return _lstOriginalList; }
        }
        #endregion

        #region public List<T> RemovedObjects
        /// <summary>
        /// Collection of objects removed from the collection, but not yet the db.
        /// </summary>
        public List<T> RemovedObjects
        {
            get { return _lstRemovedObjects; }
            set { _lstRemovedObjects = value; }
        }
        #endregion

        #region protected bool IsLoading
        /// <summary>
        /// Gets or sets a value indicating whether or not objects being added to the collection 
        /// should have their initial state set to Current or New.
        /// </summary>
        protected bool IsLoading
        {
            get { return _isLoading; }
            set { _isLoading = value; }
        }
        #endregion

        #region protected DateTime UpdateDate
        protected DateTime UpdateDate
        {
            get { return _UpdateDate; }
            set { _UpdateDate = value; }
        }
        #endregion
        
        #region public BaseCollection()
        public BaseCollection()
        {
            
        } 
        #endregion

        #region public BaseCollection( int parentId )
        public BaseCollection( int parentId )
        {

            _intParentId = parentId;

        }
        #endregion

        #region protected override object AddNewCore()
        protected override object AddNewCore()
        {

            T myObject = new T();
            this.Add( myObject );

            return myObject;

        } 
        #endregion
        
        #region protected override void RemoveItem( int index )
        protected override void RemoveItem( int index )
        {

            if( !this.Items[index].MyState.Equals( MyObjectState.New ) )
            {
                if( ParentId < 0 )
                {
                    this.Items[index].Remove( true );
                    _lstOriginalList.Remove( this.Items[index] );
                }
                else
                {
                    this.Items[index].Remove( false );
                    _lstRemovedObjects.Add( this.Items[index] );
                }
            }

            base.RemoveItem( index );

        }
        #endregion

        #region public virtual void CleanCollection()
        /// <summary>
        /// Clears all of the objects from the collection that are currently in a removed state
        /// </summary>
        public virtual void CleanCollection()
        {

            // updating the collection
            this._lstRemovedObjects.Clear();

        }
        #endregion
        
        // Searching
        #region protected override bool SupportsSearchingCore
        protected override bool SupportsSearchingCore
        {
            get { return true; }
        }
        #endregion

        #region protected override int FindCore( PropertyDescriptor prop, object key )
        protected override int FindCore( PropertyDescriptor prop, object key )
        {
            // Get the property info for the specified property.
            PropertyInfo propInfo = typeof( T ).GetProperty( prop.Name );
            T item;

            if( key != null )
            {

                // potential find method
                //Employee em = elist.Find(delegate(Employee e) { return e.FirstName == “Mk”; });
                //((List<T>)this.Items).Find( delegate(T e) { return propInfo.GetValue( e, null ).Equals( key ); } );



                // Loop through the items to see if the key value matches the property value.
                for( int i = 0; i < Count; ++i )
                {
                    item = (T)Items[i];
                    if( propInfo.GetValue( item, null ).Equals( key ) )
                        return i;
                }
            }
            return -1;
        }
        #endregion

        #region public int Find( string property, object key )
        public int Find( string property, object key )
        {
            // Check the properties for a property with the specified name.
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties( typeof( T ) );
            PropertyDescriptor prop = properties.Find( property, true );

            // If there is not a match, return -1 otherwise pass search to FindCore method.
            if( prop == null )
                return -1;
            else
                return FindCore( prop, key );
        }
        #endregion




        // Sorting

        #region protected override bool SupportsSortingCore
        protected override bool SupportsSortingCore
        {
            get { return true; }
        }
        #endregion

        #region protected override bool IsSortedCore
        protected override bool IsSortedCore
        {
            get { return (_sorts != null); }
        }
        #endregion

        #region public bool SupportsAdvancedSorting
        public bool SupportsAdvancedSorting
        {
            get { return true; }
        }
        #endregion

        #region public ListSortDescriptionCollection SortDescriptions
        public ListSortDescriptionCollection SortDescriptions
        {
            get { return (_sorts == null) ? null : _sorts.Sorts; }
        }
        #endregion

        #region protected override PropertyDescriptor SortPropertyCore
        protected override PropertyDescriptor SortPropertyCore
        {
            get { return (_sorts == null) ? null : _sorts.PrimaryProperty; }
        }
        #endregion

        #region protected override ListSortDirection SortDirectionCore
        protected override ListSortDirection SortDirectionCore
        {
            get{ return (_sorts == null) ? ListSortDirection.Ascending : _sorts.PrimaryDirection; }
        }
        #endregion

        #region public void ApplySort( ListSortDescriptionCollection sortCollection )
        public void ApplySort( ListSortDescriptionCollection sortCollection )
        {
            bool oldRaise = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            try
            {
                PropertyComparerCollection<T> tmp = new PropertyComparerCollection<T>( sortCollection );

                List<T> items = new List<T>( this );

                items.Sort( tmp );

                int index = 0;
                foreach( T item in items )
                {
                    SetItem( index++, item );
                }
                _sorts = tmp;

            }
            finally
            {
                RaiseListChangedEvents = oldRaise;
                ResetBindings();
            }
        }
        #endregion

        #region public void ApplySort( string propertyName, ListSortDirection direction )
        public void ApplySort( string propertyName, ListSortDirection direction )
        {
            // Check the properties for a property with the specified name.
            PropertyDescriptor prop = TypeDescriptor.GetProperties( typeof( T ) )[propertyName];

            if( prop == null )
                throw new ArgumentException( propertyName + " is not a valid property for type:" + typeof( T ).Name );
            else
                ApplySortCore( prop, direction );
        } 
        #endregion

        #region protected override void ApplySortCore( PropertyDescriptor property, ListSortDirection direction )
        protected override void ApplySortCore( PropertyDescriptor property, ListSortDirection direction )
        {

            ListSortDescription[] arr = { new ListSortDescription( property, direction ) };
            ApplySort( new ListSortDescriptionCollection( arr ) );

        }
        #endregion

        #region protected override void RemoveSortCore()
        protected override void RemoveSortCore()
        {
            _sorts = null;
        }
        #endregion

        #region public void RemoveSort()
        public void RemoveSort()
        {
            RemoveSortCore();
        } 
        #endregion



        



        
        // Filtering

        #region public bool SupportsFiltering
        public bool SupportsFiltering
        {
            get { return true; }
        } 
        #endregion

        #region public void RemoveFilter()
        public void RemoveFilter()
        {
            if( Filter != null ) 
                Filter = null;
        } 
        #endregion

        #region public string Filter
        public string Filter
        {
            get { return _strFilter; }

            set
            {
                if( _strFilter == value ) return;

                // If the value is not null or empty, but doesn't match expected format, throw an exception.
                if( !string.IsNullOrEmpty( value ) && !Regex.IsMatch( value, BuildRegExForFilterFormat(), RegexOptions.Singleline | RegexOptions.IgnoreCase ) )
                    throw new ArgumentException( "Filter is not in the format: propName[<>=]'value'." );

                //Turn off list-changed events.
                this.RaiseListChangedEvents = false;

                // If the value is null or empty, reset list.
                if( string.IsNullOrEmpty( value ) )
                {
                    ResetList();
                }
                else
                {
                    int count = 0;
                    string[] matches = value.Split( new string[] { " AND " }, StringSplitOptions.RemoveEmptyEntries );

                    while( count < matches.Length )
                    {
                        string filterPart = matches[count].ToString();

                        // Check to see if the filter was set previously.
                        // Also, check if current filter is a subset of the previous filter.
                        if( !String.IsNullOrEmpty( _strFilter ) && !value.Contains( _strFilter ) )
                            ResetList();

                        // Parse and apply the filter.
                        SingleFilterInfo filterInfo = ParseFilter( filterPart );
                        ApplyFilter( filterInfo );
                        count++;
                    }
                }

                // Set the filter value and turn on list changed events.
                _strFilter = value;
                this.RaiseListChangedEvents = true;
                OnListChanged( new ListChangedEventArgs( ListChangedType.Reset, -1 ) );
            }
        } 
        #endregion
        
        #region public static string BuildRegExForFilterFormat()
        // Build a regular expression to determine if filter is in correct format.
        public static string BuildRegExForFilterFormat()
        {
            StringBuilder regex = new StringBuilder();

            // Look for optional literal brackets, followed by word characters or space.
            regex.Append( @"\[?[\w\s]+\]?\s?" );

            // Add the operators: >, <, =, or Like.
            regex.Append( @"[><=]|Like" );

            //Add optional space followed by optional quote and any character followed by the optional quote.
            regex.Append( @"\s?'?.+'?" );

            return regex.ToString();
        } 
        #endregion

        #region private void ResetList()
        private void ResetList()
        {
            this.ClearItems();

            foreach( T t in _lstOriginalList )
            {
                this.Items.Add( t );
            }

            if( IsSortedCore )
                ApplySortCore( SortPropertyCore, SortDirectionCore );
        } 
        #endregion
        
        #region protected override void OnListChanged( ListChangedEventArgs e )
        protected override void OnListChanged( ListChangedEventArgs e )
        {
          
            switch( e.ListChangedType )
            {

                case ListChangedType.Reset:
                    AllowNew = (string.IsNullOrEmpty( Filter )) ? true : false;

                    if( e.NewIndex > -1 )
                    {
                        this.Items[e.NewIndex].Reset();
                    }
                    break;


                case ListChangedType.ItemAdded:

                    // if the collection is owned, objects added have their state set to new.  The 
                    // object is not new, but it is in relation to the collection. however, if I'm adding during initialization,
                    // i need to leave the defendant state alone. 
                    
                    if( this._intParentId  > 0 && !IsLoading )
                    {
                        this[e.NewIndex].RaiseChangedEvents = false;
                        this[e.NewIndex].MyState = MyObjectState.New;
                        this[e.NewIndex].RaiseChangedEvents = true;
                    }

                    _lstOriginalList.Add( this[e.NewIndex] );

                    if( !String.IsNullOrEmpty( Filter ) )
                    {
                        string cachedFilter = this.Filter;
                        this.Filter = "";
                        this.Filter = cachedFilter;
                    }
                    break;

                case ListChangedType.ItemDeleted:
                    //_lstOriginalList.RemoveAt( e.NewIndex );
                    break;
            }

            base.OnListChanged( e );
        } 
        #endregion
        
        #region internal void ApplyFilter( SingleFilterInfo filterParts )
        internal void ApplyFilter( SingleFilterInfo filterParts )
        {

            List<T> results;

            // Check to see if the property type we are filtering by implements the IComparable interface.
            Type interfaceType = TypeDescriptor.GetProperties( typeof( T ) )[filterParts.PropName].PropertyType.GetInterface( "IComparable" );

            if( interfaceType == null )
                throw new InvalidOperationException( "Filtered property must implement IComparable." );

            results = new List<T>();

            // Check each value and add to the results list.
            foreach( T item in this )
            {
                if( filterParts.PropDesc.GetValue( item ) != null )
                {
                    IComparable compareValue;
                    if( filterParts.PropName == "Employers" )
                    {

                        // probably need to find the exact employer here.  and then implement icomparabel on that particular employer
                        compareValue = (IComparable)filterParts.PropDesc.GetValue( item );

                        EmployersDefendant emps = (EmployersDefendant)filterParts.PropDesc.GetValue( item );

                        foreach( EmployerDefendant emp in emps )
                        {
                            if( string.IsNullOrEmpty( emp.SeparationDate ) )
                            {
                                if( emp.EmployerName.StartsWith( filterParts.CompareValue.ToString(), StringComparison.CurrentCultureIgnoreCase ) )
                                {
                                    results.Add( item );
                                    break;
                                }
                            }
                        }

                    }
                    else
                    {


                        compareValue = (IComparable)filterParts.PropDesc.GetValue( item );


                        // like operator works differently than the >, < and = operators, so handle it by itself.
                        if( filterParts.OperatorValue == FilterOperator.Like )
                        {
                            if( compareValue.ToString().StartsWith( filterParts.CompareValue.ToString(), StringComparison.CurrentCultureIgnoreCase ) )
                            {
                                results.Add( item );
                            }
                        }
                        else
                        {

                            int result = compareValue.CompareTo( filterParts.CompareValue );

                            if( filterParts.OperatorValue == FilterOperator.EqualTo && result == 0 )
                                results.Add( item );

                            else if( filterParts.OperatorValue == FilterOperator.GreaterThan && result > 0 )
                                results.Add( item );

                            else if( filterParts.OperatorValue == FilterOperator.LessThan && result < 0 )
                                results.Add( item );
                        }






                        //if( compareValue.ToString().StartsWith( filterParts.CompareValue.ToString(), StringComparison.CurrentCultureIgnoreCase ) )
                        //{
                        //    results.Add( item );
                        //}
                    }
                }
                
            }

            // clearing the current list and adding the found results back in
            this.ClearItems();
            foreach( T itemFound in results )
                this.Add( itemFound );
            
        } 
        #endregion

        #region internal SingleFilterInfo ParseFilter( string filterPart )
        internal SingleFilterInfo ParseFilter( string filterPart )
        {
            string[] filterStringParts;
            SingleFilterInfo filterInfo = new SingleFilterInfo();
            filterInfo.OperatorValue = DetermineFilterOperator( filterPart );

            switch( filterInfo.OperatorValue )
            {
                case FilterOperator.GreaterThan:
                    filterStringParts = filterPart.Split( new string[] { ">" }, StringSplitOptions.RemoveEmptyEntries );
                    break;

                case FilterOperator.LessThan:
                    filterStringParts = filterPart.Split( new string[] { "<" }, StringSplitOptions.RemoveEmptyEntries );
                    break;

                case FilterOperator.EqualTo:
                    filterStringParts = filterPart.Split( new string[] { "=" }, StringSplitOptions.RemoveEmptyEntries );
                    break;

                case FilterOperator.Like:
                    filterStringParts = filterPart.Split( new string[] { filterInfo.OperatorValue.ToString() }, StringSplitOptions.RemoveEmptyEntries );
                    break;

                default:

                    throw new ArgumentOutOfRangeException( "Filter Operator", "No operator was found.  Valid operators are >[=], <[=], = and 'Like'." );

            }


            

            filterInfo.PropName = filterStringParts[0].Replace( "[", "" ).Replace( "]", "" ).Replace( " AND ", "" ).Trim();

            // Get the property descriptor for the filter property name.
            PropertyDescriptor filterPropDesc = TypeDescriptor.GetProperties( typeof( T ) )[filterInfo.PropName];

            // Convert the filter compare value to the property type.
            if( filterPropDesc == null )
                throw new InvalidOperationException( "Specified property to filter " + filterInfo.PropName + " on does not exist on type: " + typeof( T ).Name );

            filterInfo.PropDesc = filterPropDesc;

            string comparePartNoQuotes = StripOffQuotes( filterStringParts[1] );

            try
            {
                TypeConverter converter = TypeDescriptor.GetConverter( filterPropDesc.PropertyType );
                filterInfo.CompareValue = converter.ConvertFromString( comparePartNoQuotes );
            }
            catch( NotSupportedException )
            {
                throw new InvalidOperationException( "Specified filter value " + comparePartNoQuotes + " can not be converted" +
                    "from string. Implement a type converter for " + filterPropDesc.PropertyType.ToString() );
            }

            return filterInfo;
        } 
        #endregion

        #region internal FilterOperator DetermineFilterOperator( string filterPart )
        internal FilterOperator DetermineFilterOperator( string filterPart )
        {
            // Determine the filter's operator.
            if( Regex.IsMatch( filterPart, "[^>^<]=" ) )
                return FilterOperator.EqualTo;
            else if( Regex.IsMatch( filterPart, "<[^>^=]" ) )
                return FilterOperator.LessThan;
            else if( Regex.IsMatch( filterPart, "[^<]>[^=]" ) )
                return FilterOperator.GreaterThan;
            else if( Regex.IsMatch( filterPart, "Like", RegexOptions.IgnoreCase ) )
                return FilterOperator.Like;
            else
                return FilterOperator.None;
        } 
        #endregion

        #region internal static string StripOffQuotes( string filterPart )
        internal static string StripOffQuotes( string filterPart )
        {
            // Strip off quotes in compare value if they are present.
            if( Regex.IsMatch( filterPart, "'.+'" ) )
            {
                int quote = filterPart.IndexOf( '\'' );
                filterPart = filterPart.Remove( quote, 1 );
                quote = filterPart.LastIndexOf( '\'' );
                filterPart = filterPart.Remove( quote, 1 );
                filterPart = filterPart.Trim();
            }

            return filterPart;
        } 
        #endregion


    }










    #region public class PropertyComparerCollection<T> : IComparer<T>
    public class PropertyComparerCollection<T> : IComparer<T>
    {

        private readonly ListSortDescriptionCollection _sorts;
        private readonly PropertyComparer<T>[] _comparers;


        #region public ListSortDescriptionCollection Sorts
        public ListSortDescriptionCollection Sorts
        {
            get { return _sorts; }
        }
        #endregion

        #region public PropertyDescriptor PrimaryProperty
        public PropertyDescriptor PrimaryProperty
        {
            get { return (_comparers.Length < 1) ? null : _comparers[0].Property; }
        }
        #endregion

        #region public ListSortDirection PrimaryDirection
        public ListSortDirection PrimaryDirection
        {
            get
            {
                if( _comparers.Length < 1 )
                {
                    return ListSortDirection.Ascending;
                }
                else
                {
                    return (_comparers[0].Descending) ? ListSortDirection.Descending : ListSortDirection.Ascending;
                }
            }
        }
        #endregion




        #region public PropertyComparerCollection( ListSortDescriptionCollection sorts )
        public PropertyComparerCollection( ListSortDescriptionCollection sorts )
        {

            if( sorts == null )
                throw new ArgumentNullException( "sorts" );

            this._sorts = sorts;

            List<PropertyComparer<T>> list = new
            List<PropertyComparer<T>>();

            foreach( ListSortDescription item in sorts )
            {
                list.Add( new PropertyComparer<T>( item.PropertyDescriptor, item.SortDirection == ListSortDirection.Descending ) );
            }

            _comparers = list.ToArray();

        }
        #endregion




        #region int IComparer<T>.Compare( T x, T y )
        int IComparer<T>.Compare( T x, T y )
        {
            int result = 0;
            for( int i = 0; i < _comparers.Length; i++ )
            {
                result = _comparers[i].Compare( x, y );
                if( result != 0 )
                    break;
            }
            return result;
        }
        #endregion

    } 
    #endregion

    #region MyRegionpublic class PropertyComparer<T> : IComparer<T>
    public class PropertyComparer<T> : IComparer<T>
    {

        private readonly bool _descending;
        private readonly PropertyDescriptor _property;


        #region public bool Descending
        public bool Descending
        {
            get { return _descending; }
        }
        #endregion

        #region public PropertyDescriptor Property
        public PropertyDescriptor Property
        {
            get { return _property; }
        }
        #endregion




        #region public PropertyComparer( PropertyDescriptor property, bool descending )
        public PropertyComparer( PropertyDescriptor property, bool descending )
        {
            if( property == null )
                throw new ArgumentNullException( "property" );

            this._descending = descending;
            this._property = property;
        }
        #endregion


        #region public int Compare( T x, T y )
        public int Compare( T x, T y )
        {

            int value = Comparer.Default.Compare( _property.GetValue( x ), _property.GetValue( y ) );
            return _descending ? -value : value;
        }
        #endregion

    } 
    #endregion




}
