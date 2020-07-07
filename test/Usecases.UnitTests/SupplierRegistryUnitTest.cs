using Usecases.Boundaries.Inputs;
using Xunit;

namespace Usecases.UnitTests
{
    public class SupplierRegistryUnitTest
    {
        [Fact]
        public void RegisterSupplier_Then_A_Return_SupplierOutbount()
        {
            var input = new SupplierInput { CompanyName = "Robert C Martin ME", 
                EnterpriseRegistry = "16.741.284/0001-07"
            };

            var usecase = new SupplierRegistry( new SupplierMockRepository() );
            var outbound = usecase.Handle(input);

            Assert.Equal(input.EnterpriseRegistry, outbound.Id);
        }
    }
}
