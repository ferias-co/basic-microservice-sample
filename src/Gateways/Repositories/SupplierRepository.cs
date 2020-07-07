using MongoDB.Driver;
using Entities;
using Usecases.Contracts;
using Gateways.Models;
using MongoDB.Driver.Linq;

namespace Gateways.Storages
{
    public class SupplieRepository : IStorableSupplier
    {
        private IMongoCollection<SupplierDataStruct> _collection;

        public SupplieRepository(IMongoCollection<SupplierDataStruct> collection)
        {
            _collection = collection;
        }

        public void PushSupplier(Supplier supplier)
        {
            _collection.InsertOne( new SupplierDataStruct ( supplier ) );
        }

        public Supplier QuerySuppliers(string id)
        {
            var ds = _collection
                   .AsQueryable()
                       .Where(_ => id.Equals(_.Id.ToString()))
                        .SingleOrDefault();

            return new Supplier(ds.Id, ds.EnterpriseRegistry, ds.CompanyName);
        }
    }
}
