using Entities;
using Usecases.Contracts;

namespace Controllers.UnitTests
{
    public class SupplierMockRepository : IStorableSupplier
    {
        public SupplierMockRepository()
        {
        }

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
