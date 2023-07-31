using Kuleli.Shop.Domain.Common;

namespace Kuleli.Shop.Domain.Entities
{
    public class Customer : AuditableEntity
    {
        public int AccountId { get; set; }
        public string IdentityNumber { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public int Age { get; set; }

        public DateTime Birthday { get; set; }

        public Gender Gender { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        //Sadece Üyelerin Siparis verebilmesini sağlamak icin account sınıfına iliski kurmak icin Navigation Property kullandım..
        public Account Account { get; set; }

        // Müsterinin birden fazla siparisi olabileceği icin NP kullanıldı..
        public ICollection<Order> Orders { get; set; }
    
        public ICollection<ProductComment> ProductComments { get; set; }

    } 

    public enum Gender
    {
        Male=1,
        Female=2
    }
}
