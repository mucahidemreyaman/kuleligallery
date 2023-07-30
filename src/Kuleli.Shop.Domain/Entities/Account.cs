using Kuleli.Shop.Domain.Common;

namespace Kuleli.Shop.Domain.Entities
{
    public  class Account : AuditableEntity
    {
        public int CustomerId { get; set; } 
        public string Username { get; set; }

        public string Password { get; set; }

        public DateTime LastLoginDate { get; set; }

        public string LastUserIp { get; set; }
        
        //Ziyaretci ile üyeler arasındaki farkı göstermek icin Navigation Property kullandım..
        public Customer Customer { get; set; }

    }
}
