using Entities;
using Usecases.Contracts;
using Gateways.Models;
using System.Collections.Generic;
using System;
using Gateways.Mappers;

namespace Gateways.Storages
{
    public class SupplierInMemoryRepository : IStorableSupplier
    {
        private List<SupplierModel> _collection;

        public SupplierInMemoryRepository()
        {
            _collection = new List<SupplierModel>();
        }

        public void PushSupplier(Supplier supplier)
        {

            _collection.Add( new SupplierModel ( supplier ) );
        }

        public Supplier QuerySuppliers(string id)
        {
            var model = _collection.Find( _ => id == _.Id.ToString() ) 
                ?? throw new ArgumentNullException( nameof(QuerySuppliers) );

            return ModelToEntityMapper.Map(model);
        }
    }
}
