using Usecases;
using Usecases.Boundaries.Inputs;
using Xunit;

namespace Controllers.UnitTests
{
    public class SupplierControllerUnitTest
    {
        [Fact]
        public void SupplierController_Then_A_Return_SupplierOutbount()
        {
            var input = new SupplierInput
            {
                CompanyName = "Robert C Martin ME",
                EnterpriseRegistry = "16.741.284/0001-07"
            };

            var usecase = new SupplierRegistry(new SupplierMockRepository());
            var controller = new SupplierController();

            var output = controller.Post(input, usecase);

            Assert.NotNull(output.Id);
        }

    }
}
