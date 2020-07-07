using Entities;
using Usecases.Boundaries.Outputs;

namespace Usecases.Mappers
{
    public static class MapperSupplierIdOutput
    {
        public static SupplierIdOutput Map(Supplier supplier)
        {
            return new SupplierIdOutput
            {
                Id = supplier.Id.ToString()
            };
        }
    }
}
