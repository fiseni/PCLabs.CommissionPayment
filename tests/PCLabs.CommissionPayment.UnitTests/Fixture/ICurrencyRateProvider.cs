using System.Threading.Tasks;

namespace PCLabs.CommissionPayment.UnitTests.Fixture
{
    public interface ICurrencyRateProvider
    {
        Task<decimal> GetCurrencyRate();
    }
}
