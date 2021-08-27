using Manager.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Manager.Infra.Data.Interface
{
    public interface IBaseRepository<TEntity> where TEntity : Base
    {

        Task<TEntity> Create(TEntity obj);
        Task<TEntity> Update(TEntity obj);
        Task Remove(long id);
        Task<TEntity> Get(long id);
        Task<List<TEntity>> Get();

    }
}
