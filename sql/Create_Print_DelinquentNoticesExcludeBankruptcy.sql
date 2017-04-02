USE [civilfeecollections]
GO

/****** Object:  StoredProcedure [dbo].[Print_DelinquentNotices]    Script Date: 4/2/2017 11:32:37 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Programmer (modified from original)
-- Create date: 9/22/2010
-- Description:	Procedure for finding list of delinquent defendants and automatically printing notices.
-- Updated:     Contractor (09/19/2011) removed 1st and 2nd deliquency references.  
--				Updated noncompliance reference from Defendant to DefendantPlans.
-- Updated:     Contractor (10/07/2012) renamed from sp_delinquent_notices to Print_DelinquentNotices.
-- =============================================
CREATE PROCEDURE [dbo].[Print_DelinquentNoticesExcludeBankruptcy] 
(
	@input_DateTime DateTime
)
AS
BEGIN

	-- SET NOCOUNT ON added to prevent extra result sets from interfering with SELECT statements.
	SET NOCOUNT ON;

	UPDATE Defendant SET inbankruptcy=0 WHERE inbankruptcy=1 and banktupcyenddate<CURRENT_TIMESTAMP;



  SELECT lastname, firstname, street1, street2, city, stateAbbr, zip, [#ofdaysbehind]
    FROM
         (
         SELECT DISTINCT b.defendantid, b.lastname, b.firstname, b.street1, b.street2, b.city, b.stateAbbr, b.zip, b.planid, b.planname, b.[Last Payment Date], b.[Last Payment Amount], b.[current payment arrangement start date],
                b.[numberofpaymentsmadesincestartdate], payperiodtype, PlanPaymentArrangement.amount, b.Noncompliance,
				CASE 
					WHEN UPPER(payperiodtype) = 'MONTHLY' THEN DATEDIFF( MONTH, b.[current payment arrangement start date], @input_DateTime )
					WHEN UPPER(payperiodtype) = 'WEEKLY' THEN DATEDIFF( WEEK, b.[current payment arrangement start date], @input_DateTime )
					WHEN UPPER(payperiodtype) = 'BI-MONTHLY' THEN DATEDIFF( MONTH, b.[current payment arrangement start date], @input_DateTime ) * 2
					WHEN UPPER(payperiodtype) = 'BI-WEEKLY' THEN DATEDIFF( MONTH, b.[current payment arrangement start date], @input_DateTime ) * 2
                    ELSE 0
				END AS #ofpayperiodssincestartdate,
				CASE 
					WHEN UPPER(payperiodtype) = 'MONTHLY' THEN PlanPaymentArrangement.amount * DATEDIFF( MONTH, b.[current payment arrangement start date], @input_DateTime )
					WHEN UPPER(payperiodtype) = 'WEEKLY' THEN PlanPaymentArrangement.amount * DATEDIFF( WEEK, b.[current payment arrangement start date], @input_DateTime )
					WHEN UPPER(payperiodtype) = 'BI-MONTHLY' THEN PlanPaymentArrangement.amount * DATEDIFF( MONTH, b.[current payment arrangement start date], @input_DateTime ) * 2
					WHEN UPPER(payperiodtype) = 'BI-WEEKLY' THEN PlanPaymentArrangement.amount * DATEDIFF( MONTH, b.[current payment arrangement start date], @input_DateTime ) * 2
                    ELSE 0
				END AS [amountusershouldhavepaidbynow],
				CASE 
					WHEN UPPER(payperiodtype) = 'MONTHLY' THEN ((PlanPaymentArrangement.amount * DATEDIFF( MONTH, b.[current payment arrangement start date], @input_DateTime )) - b.[totalamountuserhaspaidsincestartdate] )/PlanPaymentArrangement.amount
					WHEN UPPER(payperiodtype) = 'WEEKLY' THEN ((PlanPaymentArrangement.amount * DATEDIFF( WEEK, b.[current payment arrangement start date], @input_DateTime )) - b.[totalamountuserhaspaidsincestartdate] )/PlanPaymentArrangement.amount
					WHEN UPPER(payperiodtype) = 'BI-MONTHLY' THEN ((PlanPaymentArrangement.amount * DATEDIFF( MONTH, b.[current payment arrangement start date], @input_DateTime ) * 2) - b.[totalamountuserhaspaidsincestartdate] )/PlanPaymentArrangement.amount
					WHEN UPPER(payperiodtype) = 'BI-WEEKLY' THEN ((PlanPaymentArrangement.amount * DATEDIFF( MONTH, b.[current payment arrangement start date], @input_DateTime ) * 2) - b.[totalamountuserhaspaidsincestartdate] )/PlanPaymentArrangement.amount
                    ELSE 0
				END AS #ofpaymentsuserowes,
				CASE 
					WHEN UPPER(payperiodtype) = 'MONTHLY' THEN (DATEDIFF( MONTH, b.[current payment arrangement start date], @input_DateTime ) - ((PlanPaymentArrangement.amount * DATEDIFF( MONTH, b.[current payment arrangement start date], @input_DateTime )) - b.[totalamountuserhaspaidsincestartdate] )/PlanPaymentArrangement.amount)
					WHEN UPPER(payperiodtype) = 'WEEKLY' THEN (DATEDIFF( WEEK, b.[current payment arrangement start date], @input_DateTime ) - ((PlanPaymentArrangement.amount * DATEDIFF( WEEK, b.[current payment arrangement start date], @input_DateTime )) - b.[totalamountuserhaspaidsincestartdate] )/PlanPaymentArrangement.amount )
					WHEN UPPER(payperiodtype) = 'BI-MONTHLY' THEN ((DATEDIFF( MONTH, b.[current payment arrangement start date], @input_DateTime ) * 2) - ((PlanPaymentArrangement.amount * DATEDIFF( MONTH, b.[current payment arrangement start date], @input_DateTime ) * 2) - b.[totalamountuserhaspaidsincestartdate] )/PlanPaymentArrangement.amount )
					WHEN UPPER(payperiodtype) = 'BI-WEEKLY' THEN ((DATEDIFF( MONTH, b.[current payment arrangement start date], @input_DateTime ) * 2) - ((PlanPaymentArrangement.amount * DATEDIFF( MONTH, b.[current payment arrangement start date], @input_DateTime ) * 2) - b.[totalamountuserhaspaidsincestartdate] )/PlanPaymentArrangement.amount )
                    ELSE 0
				END AS #ofpayperiodsuserhasmade,
				DATEDIFF( DAY ,[Last Payment Date], @input_datetime) AS [#ofdaysbehind]
           FROM   
                (
                SELECT a.defendantid, a.lastname, a.firstname, a.planid, a.planname, a.[Last Payment Date], a.[Last Payment Amount], MAX(a.startdate) AS [current payment arrangement start date],
                       DATEDIFF( DAY, ISNULL( [Last Payment Date], MAX(a.startdate) ), @input_DateTime) AS [dayssincelastpayment], 
	                   (SELECT COUNT(receiveddate) FROM FeePayment WHERE a.defendantid = FeePayment.defendantid AND a.planid = FeePayment.planid AND receiveddate > MAX(a.startdate)
					   ) AS [numberofpaymentsmadesincestartdate],
					   (SELECT COUNT(receiveddate) FROM FeePayment WHERE a.defendantid = FeePayment.defendantid AND a.planid = FeePayment.planid AND receiveddate > MAX(a.startdate)
					   ) AS [numberofpayperiodsincepaymentarrangementstartdate] ,
					   (SELECT ISNULL(SUM(amount),0) FROM FeePayment WHERE a.defendantid = FeePayment.defendantid AND a.planid = FeePayment.planid AND receiveddate > MAX(a.startdate)
					   ) AS [totalamountuserhaspaidsincestartdate], a.street1, a.street2, a.city, a.stateAbbr, a.zip, a.Noncompliance
                  FROM
	                   (
                       SELECT Defendant.defendantid, lastname, firstname, DefendantPlans.planid, planname, LastPayment.receiveddate AS [Last Payment Date], SUM(FeePayment.amount) AS [Last Payment Amount],
                              PlanPaymentArrangement.startdate, street1, street2, city, States.abbreviation as stateAbbr, zip, DefendantPlans.noncompliancenotice AS Noncompliance
                         FROM Defendant
				   INNER JOIN States ON Defendant.stateid = States.stateid
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
							 AND (inbankruptcy=0 OR banktupcyenddate<CURRENT_TIMESTAMP)
                     GROUP BY Defendant.defendantid, lastname, firstname, DefendantPlans.planid, planname, LastPayment.receiveddate, PlanPaymentArrangement.startdate, PlanPaymentArrangement.amount, street1, street2, city, States.abbreviation, zip, DefendantPlans.noncompliancenotice
				       ) AS a    
              GROUP BY a.defendantid, a.lastname, a.firstname, a.planid, a.planname, a.[Last Payment Date], a.[Last Payment Amount], a.street1, a.street2, a.city, a.stateAbbr, a.zip, Noncompliance
		        ) AS b
     INNER JOIN PlanPaymentArrangement ON b.defendantid = PlanPaymentArrangement.defendantid AND b.planid = PlanPaymentArrangement.planid AND b.[current payment arrangement start date] = PlanPaymentArrangement.startdate
     INNER JOIN PayPeriodTypes ON PlanPaymentArrangement.payperiodtypeid = PayPeriodTypes.payperiodtypeid )
         AS z  where [#ofdaysbehind] between 46 and 181 
ORDER BY lastname, firstname, planname
END

GO


