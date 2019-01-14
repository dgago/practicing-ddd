using System.Threading.Tasks;
using tuc.core.domain.model;

namespace tuc.core.domain.data
{
  public interface IRepository<T, D, K>
    where T : AggregateRoot<K>
    where D : Entity<K>
    where K : class
  {

    #region Public Methods

    K Create(T item);

    Task<K> CreateAsync(T item);

    T FindOne(K id);

    Task<T> FindOneAsync(K id);

    D FindOneData(K id);

    Task<D> FindOneDataAsync(K id);

    void Remove(K id);

    Task RemoveAsync(K id);

    bool Replace(K id, T item);

    Task<bool> ReplaceAsync(K id, T item);

    #endregion Public Methods

  }
}