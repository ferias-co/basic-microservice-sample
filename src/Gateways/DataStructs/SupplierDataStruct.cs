using Entities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Gateways.Models
{
    [BsonIgnoreExtraElements]
    public class SupplierDataStruct
    {

        [BsonId]
        public ObjectId _Id { get; set; }

        [BsonElement("company_id")]
        public Guid Id { get; set; }

        [BsonElement("company_name")]
        public string CompanyName { get; set; }

        [BsonElement("enterprise_registry")]
        public string EnterpriseRegistry { get; set; }


        public SupplierDataStruct(Supplier supplier)
        {
            Id = supplier.Id;
            CompanyName = supplier.CompanyName;
            EnterpriseRegistry = supplier.EntepriseRegistry;
        }

        public SupplierDataStruct() { 
        
        }
    }
}
