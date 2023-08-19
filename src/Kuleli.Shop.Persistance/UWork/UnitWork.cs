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
        //private readonly IServiceProvider _serviceProvider; // ServiceProvider Objesi dependency injectionda ki servise belirli bir adla erişmemizi saglar
        private readonly KuleliGalleryContext _context;

        public UnitWork(KuleliGalleryContext context)
        {
            _repositories = new Dictionary<Type, object>();
            //_serviceProvider = serviceProvider;
            _context = context;
        }

        /// <summary>
        /// Bu UnitOfWork katmanında kayıtlı olan tüm repolar icin tek seferde calıstırır.
        /// hata olursa buradan exception fırlatır


        public async Task<bool> CommitAsync()
        {
            var result = false;
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var trackdEntities = _context.ChangeTracker.Entries<AuditableEntity>().ToList();
                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();

                    return true;
                }
                catch
                {
                    await transaction.RollbackAsync();
                    throw;
                }

            }
            return result;
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

            var repository = new Repository<T>(_context);
           // var scope = _serviceProvider.CreateScope();
            _repositories.Add(typeof(IRepository<T>), repository);
            return repository;


        }

        #region Dispose

        bool _disposed = false;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                // TODO: dispose managed state (managed objects).
                //.Net'in kendi objelerini kaldırır
                _context.Dispose();
            }

            // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
            // TODO: set large fields to null.
            //Kullanılan harici dil kütüphaneleri(.Net ile yazılmamıs external kütüphaneler)
            //Örneğin görüntü islemi icin kullanılacak bir C++ kütüphanesini bellekten atılır.


            _disposed = true;
        }
        #endregion
    }
}
