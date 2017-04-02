USE [civilfeecollections]
GO

/****** Object:  StoredProcedure [dbo].[Report_AccountStatus]    Script Date: 4/2/2017 12:01:33 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/*******************************************************************************************************************
Author:  Contractor
Date:    10/07/2012
Name:    Report_AccountStatus
Version: 1.3.0.0

Module Purpose:
	This stored procedure will retreive the current payment arrangement status for a defendant.


Module Description:
	This stored procedure will retreive a defendan't payment arrangement start date, amount due each period, 
	the total amount the user has paid since the payment arrangement start date, and the number of pay periods 
    since the payment arrangement start date.

    The stored procedure first retreives all active defendant information which have account balances or a
    current payment plan (Exclusive OR).  It then calculates the amount the defendant should have paid by now:

		amount due each peiod * number of payperiods since the payment arrangement start date

	If the total amount the user has paid since the payment arrangement start date is greater than
    or equal to the amount the defendant should have paid by now, the user is in a 'Current' status.  Otherwise, 
    the user owes money and is late on making a payment.

    Next, the stored procedure determines how many payments each user is behind:
    
		( amount defendant should have paid by now - total amount user has paid since startdate ) 
			/
			amount due each period
 
    indiciates how many pay periods the defendant needs to pay in order to be current.  (If it's negative, the 
    defendant is ahead of planned payments by the number of pay periods.)  If it is positive, the stored
    procedure determines the number of payments the user has technically covered with the total amount paid 
    during the current payment arrangement period:

		number of pay periods since start date - number of pay periods the defendant needs in order to be current

    To determine the last payment date the user was considered current:

        payment arrangement start date + ( number of payperiods user has made * pay period length )

	Finally the stored procedure subtracts the last payment date the user was considered current from the date passed 
    in as a parameter into the stored procedure.  The result is the number of days the defendant is behind in 
    payments.

    The stored procedure also returns the last name, first name, plan name, last payment date, last payment amount, 
    the number of days the defendant is deliquent and the current status of the payment arrangement:
    
		> 90 days
        > 60 days    
        > 30 days
        Current


    The main issue that caused me problems was the ability for a defendant to make more than one payment between
    pay periods.  Plus, if the defendant paid more than their elected payment amount things were more complicated.
    The stored procedure gives the defendant the benefit of the doubt if they have made more payments
    than what is currently owed.  This keeps all of the reports and data items, such as the payment
    arrangement end date in synch.

    It is ugly and unfactored.  Good luck.    

	
Calling Arguments:

	Name            I/O Description
	--------------- --- ----------------------------------------------------------------------------------------------
	@input_DateTime	 I  The date to determine account deliquency from.

Change History:

	Author          Date       Description
	--------------- ---------- ---------------------------------------------------------------------------------------
	Contractor      04/25/2009 Original Code
    Contractor      06/02/2009 Bi-Weekly # pay periods was calculated incorrectly.  Fixed so that all computed 
                               columns calculate correctly.
    Contractor      09/19/2011 removed 1st and 2nd deliquency references.  Updated noncompliance reference from
                               Defendant to DefendantPlans.
    Contractor      10/02/2012 added plan filed column and middle name
    Contractor      10/07/2012 renamed from sp_account_status_data2 to Report_AccountStatus
*******************************************************************************************************************/

ALTER PROCEDURE [dbo].[Report_AccountStatus] 
(
	@input_DateTime DateTime
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from interfering with SELECT statements.
	SET NOCOUNT ON;
	
	THROW 990100, 'SP Report_AccountStatus	NO LONGER TO BE USED.  THE SYSTEM NOW ALWAYS USES Report_AccountStatusLenientBilling THIS SHOULD NOT BE RUN.  THE SP BODY IS UNCHANGED, ONLY THIS THROW STATEMENT IS ADDED TO PREVENT ACCIDENTAL USAGE.', 10;

  SELECT lastname, firstname + ' ' + middlename as firstname, planname, isfiled,  [Last Payment Date], [Last Payment Amount],  [#ofdaysbehind],
	     CASE 
			WHEN [#ofdaysbehind] > 90 THEN '90 days'
			WHEN [#ofdaysbehind] > 60 THEN '60 days'
			WHEN [#ofdaysbehind] > 30 THEN '30 days'
			ELSE 'Current' 
		 END as deliquentstatus, Noncompliance
    FROM
         (
         SELECT DISTINCT b.defendantid, b.lastname, b.firstname, b.middlename, b.planid, b.planname, b.isfiled, b.[Last Payment Date], b.[Last Payment Amount], b.[current payment arrangement start date],
                b.[numberofpaymentsmadesincestartdate], payperiodtype, PlanPaymentArrangement.amount, b.Noncompliance,
				CASE 
					WHEN UPPER(payperiodtype) = 'MONTHLY' THEN DATEDIFF( MONTH, b.[current payment arrangement start date], @input_datetime )
					WHEN UPPER(payperiodtype) = 'WEEKLY' THEN DATEDIFF( WEEK, b.[current payment arrangement start date], @input_datetime )
					WHEN UPPER(payperiodtype) = 'BI-MONTHLY' THEN DATEDIFF( MONTH, b.[current payment arrangement start date], @input_datetime ) * 2
					WHEN UPPER(payperiodtype) = 'BI-WEEKLY' THEN DATEDIFF( MONTH, b.[current payment arrangement start date], @input_datetime ) * 2
                    ELSE 0
				END AS #ofpayperiodssincestartdate,
				CASE 
					WHEN UPPER(payperiodtype) = 'MONTHLY' THEN PlanPaymentArrangement.amount * DATEDIFF( MONTH, b.[current payment arrangement start date], @input_datetime )
					WHEN UPPER(payperiodtype) = 'WEEKLY' THEN PlanPaymentArrangement.amount * DATEDIFF( WEEK, b.[current payment arrangement start date], @input_datetime )
					WHEN UPPER(payperiodtype) = 'BI-MONTHLY' THEN PlanPaymentArrangement.amount * DATEDIFF( MONTH, b.[current payment arrangement start date], @input_datetime ) * 2
					WHEN UPPER(payperiodtype) = 'BI-WEEKLY' THEN PlanPaymentArrangement.amount * DATEDIFF( MONTH, b.[current payment arrangement start date], @input_datetime ) * 2
                    ELSE 0
				END AS [amountusershouldhavepaidbynow],
				CASE 
					WHEN UPPER(payperiodtype) = 'MONTHLY' THEN ((PlanPaymentArrangement.amount * DATEDIFF( MONTH, b.[current payment arrangement start date], @input_datetime )) - b.[totalamountuserhaspaidsincestartdate] )/PlanPaymentArrangement.amount
					WHEN UPPER(payperiodtype) = 'WEEKLY' THEN ((PlanPaymentArrangement.amount * DATEDIFF( WEEK, b.[current payment arrangement start date], @input_datetime )) - b.[totalamountuserhaspaidsincestartdate] )/PlanPaymentArrangement.amount
					WHEN UPPER(payperiodtype) = 'BI-MONTHLY' THEN ((PlanPaymentArrangement.amount * DATEDIFF( MONTH, b.[current payment arrangement start date], @input_datetime ) * 2) - b.[totalamountuserhaspaidsincestartdate] )/PlanPaymentArrangement.amount
					WHEN UPPER(payperiodtype) = 'BI-WEEKLY' THEN ((PlanPaymentArrangement.amount * DATEDIFF( MONTH, b.[current payment arrangement start date], @input_datetime ) * 2) - b.[totalamountuserhaspaidsincestartdate] )/PlanPaymentArrangement.amount
                    ELSE 0
				END AS #ofpaymentsuserowes,
				CASE 
					WHEN UPPER(payperiodtype) = 'MONTHLY' THEN (DATEDIFF( MONTH, b.[current payment arrangement start date], @input_datetime ) - ((PlanPaymentArrangement.amount * DATEDIFF( MONTH, b.[current payment arrangement start date], @input_datetime )) - b.[totalamountuserhaspaidsincestartdate] )/PlanPaymentArrangement.amount)
					WHEN UPPER(payperiodtype) = 'WEEKLY' THEN (DATEDIFF( WEEK, b.[current payment arrangement start date], @input_datetime ) - ((PlanPaymentArrangement.amount * DATEDIFF( WEEK, b.[current payment arrangement start date], @input_datetime )) - b.[totalamountuserhaspaidsincestartdate] )/PlanPaymentArrangement.amount )
					WHEN UPPER(payperiodtype) = 'BI-MONTHLY' THEN ((DATEDIFF( MONTH, b.[current payment arrangement start date], @input_datetime ) * 2) - ((PlanPaymentArrangement.amount * DATEDIFF( MONTH, b.[current payment arrangement start date], @input_datetime ) * 2) - b.[totalamountuserhaspaidsincestartdate] )/PlanPaymentArrangement.amount )
					WHEN UPPER(payperiodtype) = 'BI-WEEKLY' THEN ((DATEDIFF( MONTH, b.[current payment arrangement start date], @input_datetime ) * 2) - ((PlanPaymentArrangement.amount * DATEDIFF( MONTH, b.[current payment arrangement start date], @input_datetime ) * 2) - b.[totalamountuserhaspaidsincestartdate] )/PlanPaymentArrangement.amount )
                    ELSE 0
				END AS #ofpayperiodsuserhasmade,
				CASE 
					WHEN UPPER(payperiodtype) = 'MONTHLY' THEN DATEDIFF( DAY ,DATEADD( MONTH, (DATEDIFF( MONTH, b.[current payment arrangement start date], @input_datetime ) - ((PlanPaymentArrangement.amount * DATEDIFF( MONTH, b.[current payment arrangement start date], @input_datetime )) - b.[totalamountuserhaspaidsincestartdate] )/PlanPaymentArrangement.amount), b.[current payment arrangement start date] ), @input_datetime)
					WHEN UPPER(payperiodtype) = 'WEEKLY' THEN DATEDIFF( DAY ,DATEADD( WEEK, (DATEDIFF( WEEK, b.[current payment arrangement start date], @input_datetime ) - ((PlanPaymentArrangement.amount * DATEDIFF( WEEK, b.[current payment arrangement start date], @input_datetime )) - b.[totalamountuserhaspaidsincestartdate] )/PlanPaymentArrangement.amount ), b.[current payment arrangement start date] ), @input_datetime)
					WHEN UPPER(payperiodtype) = 'BI-MONTHLY' THEN DATEDIFF( DAY ,DATEADD( MONTH, ((DATEDIFF( MONTH, b.[current payment arrangement start date], @input_datetime ) * 2) - ((PlanPaymentArrangement.amount * DATEDIFF( MONTH, b.[current payment arrangement start date], @input_datetime ) * 2) - b.[totalamountuserhaspaidsincestartdate] )/PlanPaymentArrangement.amount ) * 2, b.[current payment arrangement start date] ), @input_datetime)
					WHEN UPPER(payperiodtype) = 'BI-WEEKLY' THEN DATEDIFF( DAY ,DATEADD( WEEK, ((DATEDIFF( MONTH, b.[current payment arrangement start date], @input_datetime ) * 2) - ((PlanPaymentArrangement.amount * DATEDIFF( MONTH, b.[current payment arrangement start date], @input_datetime ) * 2) - b.[totalamountuserhaspaidsincestartdate] )/PlanPaymentArrangement.amount ) * 2, b.[current payment arrangement start date] ), @input_datetime)
                    ELSE 0
				END AS [#ofdaysbehind]
           FROM   
                (
                SELECT a.defendantid, a.lastname, a.firstname, a.middlename, a.planid, a.planname, a.isfiled, a.[Last Payment Date], a.[Last Payment Amount], MAX(a.startdate) AS [current payment arrangement start date],
                       DATEDIFF( DAY, ISNULL( [Last Payment Date], MAX(a.startdate) ), @input_datetime) AS [dayssincelastpayment], 
	                   (SELECT COUNT(receiveddate) FROM FeePayment WHERE a.defendantid = FeePayment.defendantid AND a.planid = FeePayment.planid AND receiveddate > MAX(a.startdate)
					   ) AS [numberofpaymentsmadesincestartdate],
					   (SELECT COUNT(receiveddate) FROM FeePayment WHERE a.defendantid = FeePayment.defendantid AND a.planid = FeePayment.planid AND receiveddate > MAX(a.startdate)
					   ) AS [numberofpayperiodsincepaymentarrangementstartdate] ,
					   (SELECT ISNULL(SUM(amount),0) FROM FeePayment WHERE a.defendantid = FeePayment.defendantid AND a.planid = FeePayment.planid AND receiveddate > MAX(a.startdate)
					   ) AS [totalamountuserhaspaidsincestartdate], a.street1, a.street2, a.Noncompliance
                  FROM
	                   (
                       SELECT Defendant.defendantid, lastname, firstname, middlename, DefendantPlans.planid, planname, isfiled, LastPayment.receiveddate AS [Last Payment Date], SUM(FeePayment.amount) AS [Last Payment Amount],
                              PlanPaymentArrangement.startdate, street1, street2, DefendantPlans.noncompliancenotice AS Noncompliance
                         FROM Defendant
              LEFT OUTER JOIN DefendantPlans ON Defendant.defendantid = DefendantPlans.defendantid
              LEFT OUTER JOIN (
	                          SELECT defendantid, planid, MAX(receiveddate) AS receiveddate
                                FROM FeePayment
	                        GROUP BY defendantid, planid
                              ) AS LastPayment ON DefendantPlans.defendantid = LastPayment.defendantid AND DefendantPlans.planid = LastPayment.planid  
              LEFT OUTER JOIN FeePayment ON LastPayment.defendantid = FeePayment.defendantid AND FeePayment.planid = LastPayment.planid AND FeePayment.receiveddate = LastPayment.receiveddate
                   INNER JOIN PlanPaymentArrangement ON DefendantPlans.defendantid = PlanPaymentArrangement.defendantid AND DefendantPlans.planid = PlanPaymentArrangement.planid
                        WHERE Defendant.active = 1 AND DefendantPlans.planid IS NOT NULL AND NOT( Defendant.street1 = '' AND Defendant.street2 = '')
				              AND NOT EXISTS (
					                         SELECT defendantid, planid
						                       FROM (
					                                SELECT defendantid, planid, SUM(amount) AS total
													  FROM PlanFee 
											      GROUP BY defendantid, planid
												     UNION
												    SELECT defendantid, planid, -SUM( amount  ) AS total
												      FROM FeePayment
												  GROUP BY defendantid, planid
											        ) AS Transactions
										   	  WHERE Transactions.defendantid = DefendantPlans.defendantid AND Transactions.planid = DefendantPlans.planid 
										   GROUP BY defendantid, planid
										     HAVING SUM(total) = 0
										     )
                     GROUP BY Defendant.defendantid, lastname, firstname, middlename, DefendantPlans.planid, planname, isfiled, LastPayment.receiveddate, PlanPaymentArrangement.startdate, PlanPaymentArrangement.amount, street1, street2, DefendantPlans.noncompliancenotice
				       ) AS a    
              GROUP BY a.defendantid, a.lastname, a.firstname, a.middlename, a.planid, a.planname, a.isfiled, a.[Last Payment Date], a.[Last Payment Amount], a.street1, a.street2, Noncompliance
		        ) AS b
     INNER JOIN PlanPaymentArrangement ON b.defendantid = PlanPaymentArrangement.defendantid AND b.planid = PlanPaymentArrangement.planid AND b.[current payment arrangement start date] = PlanPaymentArrangement.startdate
     INNER JOIN PayPeriodTypes ON PlanPaymentArrangement.payperiodtypeid = PayPeriodTypes.payperiodtypeid )
         AS z -- where [Last Payment Amount] is not null --and DateDiff(Day, [Last Payment Date], getDate()) > 30
ORDER BY lastname, firstname, planname


END

GO


