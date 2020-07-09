using Entities;
using Usecases.Boundaries.Inputs;

namespace Usecases.Mappers
{
    public static class MapperSupplierOutput
    {
        public static SupplierOutput Map(Supplier supplier)
        {
            return new SupplierOutput
            {
                Id                  = supplier.Id.ToString(),
                CompanyName         = supplier.CompanyName,
                EnterpriseRegistry  = supplier.EntepriseRegistry
            };
        }
    }
    
}
