using Kuleli.Shop.Domain.Common;

namespace Kuleli.Shop.Domain.Entities
{
    public class Category : AuditableEntity
    {
        public string Name { get; set; }
    }
}
