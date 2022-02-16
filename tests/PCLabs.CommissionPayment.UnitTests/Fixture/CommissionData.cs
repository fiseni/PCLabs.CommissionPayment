using System.Collections.Generic;

namespace PCLabs.CommissionPayment.UnitTests.Fixture
{
    public class CommissionData
    {
        public decimal CommisionSumIncVat { get; set; }
        public List<CommissionItemData> Items { get; set; } = new();
    }
}