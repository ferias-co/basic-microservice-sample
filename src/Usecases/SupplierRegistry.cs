using Entities;
using Usecases.Boundaries.Inputs;
using Usecases.Boundaries.Outputs;
using Usecases.Contracts;

namespace Usecases
{
    public class SupplierRegistry : IHandleable<SupplierInput, SupplierIdOutput>
    {
        private readonly IStorableSupplier _storage;

        public SupplierRegistry(IStorableSupplier storage) {
            _storage = storage;
        }

        public SupplierIdOutput Handle(SupplierInput input)
        {
            Supplier supplier = SupplierMapper(input);

            _storage.PushSupplier(supplier);
            return MapperSupplierOutput(supplier);
        }

        public static SupplierIdOutput MapperSupplierOutput(Supplier supplier)
        {
            return new SupplierIdOutput
            {
                Id = supplier.Id.ToString()
            };
        }

        public static Supplier SupplierMapper(SupplierInput input)
        {
            return new Supplier(input.EnterpriseRegistry, input.CompanyName);
        }
    }
}
