using Entities;

namespace Usecases.Boundaries.Inputs
{
    public struct SupplierOutput
    {
        public string Id { get; set; }
        public string CompanyName { get; set; }
        public string EnterpriseRegistry { get; set; }

        public SupplierOutput(Supplier supplier) 
        {
            Id = supplier.Id.ToString();
            CompanyName = supplier.CompanyName;
            EnterpriseRegistry = supplier.EntepriseRegistry;
        }
    }
}
