using System;

namespace PCLabs.CommissionPayment.UnitTests.Fixture
{
    public class InvoiceRawData
    {
        /// <summary>
        /// WebERP_Finance.dbo.Invoices Inv_Id
        /// </summary>
        public int InvoiceId { get; set; }

        /// <summary>
        /// WebERP.dbo.Agent_Agents AgentID
        /// </summary>

        public int AgentID { get; set; }
        /// <summary>
        /// WebERP.dbo.Agent_Agents AgentName
        /// </summary>
        public string AgentName { get; set; }

        /// <summary>
        /// WebERP.dbo.Agent_Agents EnglishFirstName (InsuranceComp)
        /// </summary>
        public string InsuranceCompanyName { get; set; }

        /// <summary>
        /// WebERP_Finance.dbo.Invoices NET_PRICE
        /// </summary>
        public decimal NetPrice { get; set; }

        /// <summary>
        /// WebERP_Finance.dbo.Invoices CURRENCY
        /// </summary>
        public string InvoiceCurrency { get; set; }

        /// <summary>
        /// WebERP_Finance.dbo.RECEIPTS CURRENCY
        /// </summary>
        public string ReceiptCurrency { get; set; }

        /// <summary>
        /// WebERP_Finance.dbo.Invoices RATE
        /// </summary>
        public decimal InvoiceRate { get; set; }

        /// <summary>
        /// WebERP_Finance.dbo.RECEIPTS Rate
        /// </summary>
        public decimal ReceiptRate { get; set; }

        /// <summary>
        /// WebERP_Finance.dbo.RECEIPTS Paid_Amount
        /// </summary>
        public decimal ReciptPaidAmount { get; set; }

        /// <summary>
        /// WebERP_Finance.dbo.Invoices AGENT_PCT_1
        /// </summary>
        public decimal AgentPercent1 { get; set; }

        /// <summary>
        /// WebERP_Finance.dbo.Invoices AGENT_PCT_2
        /// </summary>
        public decimal AgentPercent2 { get; set; }

        /// <summary>
        /// WebERP_Finance.dbo.Invoices AGENT_PCT_4
        /// </summary>
        public decimal AgentPercent4 { get; set; }

        /// <summary>
        /// WebERP.dbo.Agent_SaleNumber AgentNumberId
        /// </summary>
        public int AgentNumberId { get; set; }

        /// <summary>
        /// weberp.dbo.App_AgentTaxDeductionDetails InsuranceCommissionPCT
        /// </summary>
        public decimal InsuranceCommissionPCT { get; set; }

        /// <summary>
        /// WebERP.dbo.Agent_Agents Authorized_in_life
        /// </summary>
        public bool AuthorizedInLife { get; set; }

        /// <summary>
        /// WebERP.dbo.Agent_Agents Authorized_in_health
        /// </summary>
        public bool AuthorizedInHealth { get; set; }

        /// <summary>
        /// WebERP.dbo.Agent_Agents Authorized_in_General
        /// </summary>
        public bool AuthorizedInGeneral { get; set; }

        /// <summary>
        /// weberp.dbo.App_AgentTaxDeductionDetails AgentTaxDeductionAuthorization
        /// </summary>
        public bool TaxAuthorization { get; set; }

        /// <summary>
        /// WebERP.dbo.Agent_Agents AgentPermitNumber
        /// </summary>
        public int AgentPermitNumber { get; set; }

        /// <summary>
        /// WebERP.dbo.Agent_Agents AgentPermitStartDate
        /// </summary>
        public DateTime AgentPermitStartDate { get; set; }

        /// <summary>
        /// WebERP.dbo.Agent_Agents AgentPermit_ValidDate
        /// </summary>
        public DateTime AgentPermitValidDate { get; set; }

        /// <summary>
        /// weberp.dbo.App_AgentTaxDeductionDetails BooksManagementAuthorization
        /// </summary>
        public int BooksManagementAuthorization { get; set; }

        /// <summary>
        /// OWNER_ID
        /// </summary>
        public int OwnerID { get; set; }

        /// <summary>
        /// OWNER_NAME
        /// </summary>
        public int OwnerName { get; set; }

        /// <summary>
        /// BankName
        /// </summary>
        public int BankName { get; set; }

        /// <summary>
        /// BranchName
        /// </summary>
        public int BranchName { get; set; }

        /// <summary>
        /// BranchNumber
        /// </summary>
        public int BranchNumber { get; set; }

        /// <summary>
        /// BANKID
        /// </summary>
        public int BankID { get; set; }

        /// <summary>
        /// ACCOUNT_NUMBER
        /// </summary>
        public int AccountNumber { get; set; }

        /// <summary>
        /// agentPerosnalId
        /// </summary>
        public int AgentPerosnalId { get; set; }

        /// <summary>
        /// Preferred_Currency
        /// </summary>
        public int PreferredCurrency { get; set; }

        /// <summary>
        /// MasterEntityName
        /// </summary>
        public int MasterEntityName { get; set; }

        /// <summary>
        /// Receipt_Num
        /// </summary>
        public int ReceiptNum { get; set; }

        /// <summary>
        /// PolicyNumber
        /// </summary>
        public int PolicyNumber { get; set; }

        /// <summary>
        /// PolicyStartDate
        /// </summary>
        public DateTime PolicyStartDate { get; set; }

        /// <summary>
        /// PolicyEndDate
        /// </summary>
        public DateTime PolicyEndDate { get; set; }

        /// <summary>
        /// Receipt_Date
        /// </summary>
        public DateTime ReceiptDate { get; set; }

        /// <summary>
        /// IsFreezeCommPayment
        /// </summary>
        public bool IsFreezeCommissionPayment { get; set; }
        public int? CommisionPaid1 { get; set; }
        public int? CommisionPaid2 { get; set; }
        public int? CommisionPaid4 { get; set; }

        /// <summary>
        /// AGENT_NUMBER_1
        /// </summary>
        public int? AgentNumber1 { get; set; }
        /// <summary>
        /// AGENT_NUMBER_2
        /// </summary>
        public int? AgentNumber2 { get; set; }

        /// <summary>
        /// AGENT_NUMBER_4
        /// </summary>
        public int? AgentNumber4 { get; set; }

        //public bool IsDifference { get; set; }
        //public int SaleAgentNumber { get; set; }
        //public int DifferenceToPay { get; set; }
        //public int CommisionToPayIncludeDifference { get; set; }
    }
}