using Entities;
using System.Collections.Generic;

namespace Usecases.Contracts
{
    public interface IStorableSupplier
    {
        public Supplier QuerySuppliers(string id);
        public void PushSupplier(Supplier supplier);
    }
}
