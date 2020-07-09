using MongoDB.Driver;
using Entities;
using Usecases.Contracts;
using Gateways.Models;
using MongoDB.Driver.Linq;
using Gateways.Mappers;

namespace Gateways.Storages
{
    public class SupplieRepository : IStorableSupplier
    {
        private IMongoCollection<SupplierModel> _collection;

        public SupplieRepository(IMongoCollection<SupplierModel> collection)
        {
            _collection = collection;
        }

        public void PushSupplier(Supplier supplier)
        {
            _collection.InsertOne( new SupplierModel ( supplier ) );
        }

        public Supplier QuerySuppliers(string id)
        {
            var model = _collection
                   .AsQueryable()
                       .Where(_ => id.Equals(_.Id.ToString()))
                        .SingleOrDefault();

            return ModelToEntityMapper.Map(model);
        }
    }
}
