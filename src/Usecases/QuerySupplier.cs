using Entities;
using System;
using Usecases.Boundaries.Inputs;
using Usecases.Contracts;
using Usecases.Mappers;

namespace Usecases
{
    public class QuerySupplier : IHandleable<string, SupplierOutput>
    {
        private readonly IStorableSupplier _storage;

        public QuerySupplier(IStorableSupplier storage) {
            _storage = storage ?? throw new ArgumentNullException(nameof(storage));
        }

        public SupplierOutput Handle(string input)
        {
            input = input ?? throw new ArgumentNullException(nameof(input));

            Supplier supplier = _storage.QuerySuppliers(input);

            return MapperSupplierOutput.Map(supplier);
        }
    }
}
