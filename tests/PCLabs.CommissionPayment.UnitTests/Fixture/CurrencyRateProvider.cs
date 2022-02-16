using System.Threading.Tasks;

namespace PCLabs.CommissionPayment.UnitTests.Fixture
{
    public class CurrencyRateProvider : ICurrencyRateProvider
    {
        public async Task<decimal> GetCurrencyRate()
        {
            await Task.CompletedTask;
            return 1;
        }
    }
}
