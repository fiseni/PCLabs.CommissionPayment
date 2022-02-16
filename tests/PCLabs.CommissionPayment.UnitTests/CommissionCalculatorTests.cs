using FluentAssertions;
using PCLabs.CommissionPayment.UnitTests.Fixture;
using System.Threading.Tasks;
using Xunit;

namespace PCLabs.CommissionPayment.UnitTests
{
    public class CommissionCalculatorTests
    {
        private readonly CurrencyRateProvider _currencyRateProvider;
        public CommissionCalculatorTests()
        {
            _currencyRateProvider = new CurrencyRateProvider();

        }

        [Theory]
        [InlineData(1, "ILS", 1, "ILS", 1, 100, 1, 10, 2, 20, 4, 40,        1,  100, 100, 15)]
        [InlineData(1, "ILS", 1, "ILS", 1, 100, 1, 10, 2, 20, 4, 40,        1,  100, 100, 16)]
        [InlineData(1, "ILS", 1, "ILS", 1, 100, 1, 10, 2, 20, 4, 40,        1,  100, 100, 17)]
        [InlineData(1, "ILS", 1, "ILS", 1, 100, 1, 10, 2, 20, 4, 40,        1,  100, 100, 18)]
        [InlineData(1, "ILS", 1, "ILS", 1, 100, 1, 10, 2, 20, 4, 40,        1,  100, 100, 19)]
        [InlineData(1, "ILS", 1, "ILS", 1, 100, 1, 10, 2, 20, 4, 40,        1,  100, 100, 20)]
        [InlineData(1, "ILS", 1, "ILS", 1, 100, 1, 10, 2, 20, 4, 40,        1,  100, 100, 21)]
        [InlineData(1, "ILS", 1, "ILS", 1, 100, 1, 10, 2, 20, 4, 40,        1,  100, 100, 22)]
        public async Task GetCommissionItemDataReturnCorrectOutput(int agentId, string receiptCurrency, decimal receiptRate, string invoiceCurrency, decimal invoiceRate, decimal netPrice,
            int? agentNumber1, int? commisionPaid1, int? agentNumber2, int? commisionPaid2, int? agentNumber4, int? commisionPaid4,
            int? agentOutputId, decimal paidAmount, decimal commisionSum, decimal commisionPercent)
        {
            //Arrange
            var invoiceRawData = new InvoiceRawData
            {
                AgentID = agentId,
                ReceiptCurrency = receiptCurrency,
                ReceiptRate = receiptRate,
                InvoiceCurrency = invoiceCurrency,
                InvoiceRate = invoiceRate,
                NetPrice = netPrice,
                AgentNumber1 = agentNumber1,
                CommisionPaid1 = commisionPaid1,
                AgentNumber2 = agentNumber2,
                CommisionPaid2 = commisionPaid2,
                AgentNumber4 = agentNumber4,
                CommisionPaid4 = commisionPaid4,
            };

            var calculator = new CommissionCalculator(_currencyRateProvider);
            var rate = await _currencyRateProvider.GetCurrencyRate();

            // ACT
            var result = calculator.GetCommissionItemData(invoiceRawData, rate);

            // ASSERT

            result.AgentID.Should().Be(agentOutputId);
            result.PaidAmount.Should().Be(paidAmount);
            result.CommisionSum.Should().Be(commisionSum);
            result.CommisionPercent.Should().Be(commisionPercent);
        }
    }
}
