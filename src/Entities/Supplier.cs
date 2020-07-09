using Entities.CustomTypes;
using System;

namespace Entities
{
    public class Supplier
    {

        public Guid Id { get; private set; }
        public EnterpriseRegistry EntepriseRegistry { get; private set; }
        public CompanyName CompanyName { get; private set; }

        public Supplier(Guid id, EnterpriseRegistry registry, CompanyName name)
        {
            Id = id;
            EntepriseRegistry = registry;
            CompanyName = name;
        }

        public Supplier(EnterpriseRegistry registry, CompanyName name) : this(Guid.NewGuid(), registry, name)
        {

        }

    }
}
