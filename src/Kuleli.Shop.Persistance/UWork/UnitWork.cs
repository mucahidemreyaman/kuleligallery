using Kuleli.Shop.Application.Repostories;
using Kuleli.Shop.Domain.Common;
using Kuleli.Shop.Domain.UWork;
using Kuleli.Shop.Persistance.Context;
using Kuleli.Shop.Persistance.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Kuleli.Shop.Persistance.UWork
{
    public class UnitWork : IUnitwork
    {
        private Dictionary<Type, object> _repositories;
        private readonly IServiceProvider _serviceProvider; // ServiceProvider Objesi dependency injectionda ki servise belirli bir adla erişmemizi saglar
        private readonly KuleliGalleryContext _context;
        public UnitWork(IServiceProvider serviceProvider, KuleliGalleryContext context)
        {
            _repositories = new Dictionary<Type, object>();
            _serviceProvider = serviceProvider;
            _context = context;
        }

        /// <summary>
        /// Bu UnitOfWork katmanında kayıtlı olan tüm repolar icin tek seferde calıstırır.
        /// hata olursa buradan exception fırlatır


        public async Task<bool> CommitAsync()
        {
            using(var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    await _context.SaveChangesAsync();
                    transaction.Commit();
                }
                catch
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            }
          
            return true;
        }


        // yazılımcı herhangi bir repo üzerinde insert, update, delete veya select yapacaksa 
        // bu metod yardımıyla DI icerisinde kayıtlı ilgili entity için kullanılabilecek repoya erisir
        public IRepository<T> GetRepository<T>() where T : BaseEntity
        {
            //Daha önce bu repoyu talep eden bir kullanıcı olmussa aynı repoyu tekrar etmez
            //Burada sakladıgı koleksiyon içerisinden gönderir Bu da performansı arttırır.
            if (_repositories.ContainsKey(typeof(IRepository<T>)))
            {
                return (IRepository<T>)_repositories[typeof(IRepository<T>)];
            }
            // DI : DependencyInjection
            //Eğer bu repo ile ilgili UnitOfWork icin hic kullanılmamıssa tanımlı degildir.
            //Burada DI icerisinden bu repo alınır ve bundan sonraki kullanımlarda ihtiyac olabilir.
            // düsüncesi ile sınıf icerisindeki Dictionaryde saklanır..
            

            using (var scope = _serviceProvider.CreateScope())
            {
                var repository = scope.ServiceProvider.GetRequiredService<IRepository<T>>();
                _repositories.Add(typeof(IRepository<T>), repository);
                return repository;

            }
        }
    }
}
