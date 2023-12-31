﻿using Kuleli.Shop.Domain.Common;

namespace Kuleli.Shop.Domain.Entities
{
    public class Address : BaseEntity
    {

        public int CityId { get; set; }

        public string Text { get; set; }

        public City City { get; set; }

        public ICollection<Order> Orders { get; set; }

    }
}
