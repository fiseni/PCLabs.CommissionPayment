using PCLabs.CommissionPayment.UnitTests.Fixture;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PCLabs.CommissionPayment.UnitTests.Fixture
{
    public class CommissionCalculator
    {
        private readonly ICurrencyRateProvider _currencyRateProvider;

        public CommissionCalculator(ICurrencyRateProvider currencyRateProvider)
        {
            _currencyRateProvider = currencyRateProvider;
        }

        public async Task<CommissionData> GetCommissionData(List<InvoiceRawData> invoiceRawDatas)
        {
            var currencyRate = await _currencyRateProvider.GetCurrencyRate();

            var comissionData = new CommissionData();

            foreach (var invoiceRawData in invoiceRawDatas)
            {
                comissionData.Items.Add(GetCommissionItemData(invoiceRawData, currencyRate));
            }

            comissionData.CommisionSumIncVat = 0;

            return comissionData;
        }

        public CommissionItemData GetCommissionItemData(InvoiceRawData invoiceRawData, decimal currencyRate)
        {
            var commissionItemData = new CommissionItemData();

            commissionItemData.AgentID = invoiceRawData.AgentID;
            commissionItemData.PaidAmount = GetPaidAmmount(invoiceRawData, currencyRate);
            commissionItemData.CommisionPercent = GetCommissionPercent(invoiceRawData);
            commissionItemData.CommisionSum = commissionItemData.PaidAmount * commissionItemData.CommisionPercent / 100;

            return commissionItemData;
        }

        private decimal GetPaidAmmount(InvoiceRawData invoiceRawData, decimal currencyRate)
        {
            var receiptRate = invoiceRawData.ReceiptCurrency.Equals("ILS", StringComparison.OrdinalIgnoreCase) ? invoiceRawData.ReceiptRate : currencyRate;
            var conversionRate = invoiceRawData.InvoiceCurrency.Equals("ILS", StringComparison.OrdinalIgnoreCase) ? 1 : receiptRate * invoiceRawData.InvoiceRate;
            return invoiceRawData.NetPrice * conversionRate;
        }

        private decimal GetCommissionPercent(InvoiceRawData invoiceRawData)
        {
            decimal commisionPercent = 0;

            if (invoiceRawData.AgentNumber1 is not null  && (invoiceRawData.CommisionPaid1 is null || invoiceRawData.CommisionPaid1 == 0))
            {
                commisionPercent = invoiceRawData.AgentPercent1;
            }
            else if (invoiceRawData.AgentNumber2 is not null && (invoiceRawData.CommisionPaid2 is null || invoiceRawData.CommisionPaid2 == 0))
            {
                commisionPercent = invoiceRawData.AgentPercent2;
            }
            else if (invoiceRawData.AgentNumber4 is not null && (invoiceRawData.CommisionPaid4 is null || invoiceRawData.CommisionPaid4 == 0))
            {
                commisionPercent = invoiceRawData.AgentPercent4;
            }

            return commisionPercent;
        }
    }
}