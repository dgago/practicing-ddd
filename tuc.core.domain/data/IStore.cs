using System.Linq.Expressions;
using System.Threading.Tasks;

public interface IStore<T, K>
  where T : Entity<K>
  where K : class
{
  T FindOne(K id);

  Task<T> FindOneAsync(K id);

  Task<IResults<T>> FindAllAsync(Expression filter);

  Task<K> CreateAsync(T ritem);

  K Create(T ritem);

  Task<bool> ReplaceAsync(K id, T ritem);

  bool Replace(K id, T ritem);
}
