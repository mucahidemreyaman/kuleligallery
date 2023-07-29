using Kuleli.Shop.Domain.Common;

namespace Kuleli.Shop.Domain.Entities
{
    public class Products : AuditableEntity
    {
      

        public string CategoryId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int UnitInStock { get; set; }

        public int UnitPrice { get; set; }

       
    }
}
