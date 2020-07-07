using Entities;
using System.Collections.Generic;
using Usecases.Boundaries.Inputs;
using Usecases.Contracts;

namespace Usecases
{
    public class QuerySupplier : IHandleable<string, SupplierOutput>
    {
        private readonly IStorableSupplier _storage;

        public QuerySupplier(IStorableSupplier storage) {
            _storage = storage;
        }

        public SupplierOutput Handle(string input)
        {
            Supplier supplier = _storage.QuerySuppliers(input);
            return new SupplierOutput(supplier);
        }
    }
}
