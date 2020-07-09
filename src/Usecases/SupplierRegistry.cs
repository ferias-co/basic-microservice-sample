using Entities;
using System;
using Usecases.Boundaries.Inputs;
using Usecases.Boundaries.Outputs;
using Usecases.Contracts;
using Usecases.Mappers;

namespace Usecases
{
    public class SupplierRegistry : IHandleable<SupplierInput, SupplierIdOutput>
    {
        private readonly IStorableSupplier _storage;

        public SupplierRegistry(IStorableSupplier storage) {
            _storage = storage ?? throw new ArgumentNullException( nameof(storage) );
        }

        public SupplierIdOutput Handle(SupplierInput input)
        {
            Supplier supplier = MapperSupplierIntput.Map(input);

            _storage.PushSupplier(supplier);

            return MapperSupplierIdOutput.Map(supplier);
        }

        

      
    }
}
