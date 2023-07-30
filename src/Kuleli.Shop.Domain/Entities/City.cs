using Kuleli.Shop.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kuleli.Shop.Domain.Entities
{
    public class City : BaseEntity
    {
        public string CityName { get; set; }

        public ICollection<Address> Addresses { get; set; }

    }
}
