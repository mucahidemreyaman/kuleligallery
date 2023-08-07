using Kuleli.Shop.Domain.Common;
using Kuleli.Shop.Domain.Entities;
using Kuleli.Shop.Persistance.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Kuleli.Shop.Persistance.Context
{
    public class KuleliGalleryContext : DbContext
    {
        public KuleliGalleryContext(DbContextOptions<KuleliGalleryContext> options) : base(options) { }

        #region DbSet
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductComment> ProductComments { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }

        #endregion

        #region ModelBuilder
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AccountMapping());
            modelBuilder.ApplyConfiguration(new AddressMapping());
            modelBuilder.ApplyConfiguration(new CategoryMapping());
            modelBuilder.ApplyConfiguration(new CityMapping());
            modelBuilder.ApplyConfiguration(new CustomerMapping());
            modelBuilder.ApplyConfiguration(new OrderMapping());
            modelBuilder.ApplyConfiguration(new OrderDetailMapping());
            modelBuilder.ApplyConfiguration(new ProductMapping());
            modelBuilder.ApplyConfiguration(new ProductCommentMapping());
            modelBuilder.ApplyConfiguration(new ProductImageMapping());


        }
        #endregion

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {

            // Herhangi bir kayıt isleminde yapilan islem ekleme ise CreateDate ve CreatedBy bilgileri otomatik olarak set edilir.
            // Herhangi bir kayıt isleminde yapilan islem guncelleme ise ModifiedDate ve ModifiedBy bilgileri otomatik olarak set edilir.
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>().ToList())
            {
                switch (entry.State)
                {                
                    // update                   
                    case EntityState.Modified:
                        entry.Entity.ModifiedDate = DateTime.Now;
                        entry.Entity.ModifiedBy = "admin";
                        break;


                         // insert
                    case EntityState.Added:
                        entry.Entity.CreateDate = DateTime.Now;
                        entry.Entity.CreatedBy = "admin";
                        break;
                    default:
                        break;
                }
            }

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

    }
}
