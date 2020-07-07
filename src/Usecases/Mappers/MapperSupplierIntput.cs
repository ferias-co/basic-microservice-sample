using Entities;
using Usecases.Boundaries.Inputs;

namespace Usecases.Mappers
{
    public static class MapperSupplierIntput
    {

        public static Supplier Map(SupplierInput input)
        {
            return new Supplier(input.EnterpriseRegistry, input.CompanyName);
        }
    }
}
