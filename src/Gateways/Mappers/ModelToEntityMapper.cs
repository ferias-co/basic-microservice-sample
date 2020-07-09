using Entities;
using Gateways.Models;

namespace Gateways.Mappers
{
    public static class ModelToEntityMapper
    {


        public static Supplier Map(SupplierModel model) {
            return new Supplier(model.Id, model.EnterpriseRegistry, model.CompanyName);
        }
    }
}
