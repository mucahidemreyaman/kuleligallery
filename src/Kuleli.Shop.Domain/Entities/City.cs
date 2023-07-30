using Kuleli.Shop.Domain.Common;

namespace Kuleli.Shop.Domain.Entities
{
    public class City : BaseEntity
    {
        public string CityName { get; set; }

        public ICollection<Address> Addresses { get; set; }

    }

}
