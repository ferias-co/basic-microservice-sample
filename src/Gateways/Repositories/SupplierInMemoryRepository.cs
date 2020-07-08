using Entities;
using Usecases.Contracts;
using Gateways.Models;
using System.Collections.Generic;
using System;

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
            var ds = _collection.Find(_ => id == _.Id.ToString());

            if (ds == null) throw new ArgumentNullException(nameof(id));
            
            return new Supplier(ds.Id, ds.EnterpriseRegistry, ds.CompanyName);
        }
    }
}
