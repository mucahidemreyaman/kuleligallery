using Kuleli.Shop.Application.Repostories;
using Kuleli.Shop.Domain.Common;

namespace Kuleli.Shop.Domain.UWork
{
    public interface IUnitwork : IDisposable //Merkezi bir repository yönetim sınıfı
    {
        public IRepository<T> GetRepository<T>() where T : BaseEntity;
        public Task<bool> CommitAsync();
         
    }
}
