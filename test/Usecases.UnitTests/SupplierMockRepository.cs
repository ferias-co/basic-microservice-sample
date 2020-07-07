using Entities;
using System.Collections.Generic;
using Usecases.Contracts;

namespace Usecases.UnitTests
{
    public class SupplierMockRepository : IStorableSupplier
    {
        public void PushSupplier(Supplier supplier)
        {
            return;
        }

        public Supplier QuerySuppliers(string id)
        {
            throw new System.NotImplementedException();
        }
    }
}
