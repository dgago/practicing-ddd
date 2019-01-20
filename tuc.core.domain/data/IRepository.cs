using System.Threading.Tasks;
using tuc.core.domain.model;

namespace tuc.core.domain.data
{
  public interface IRepository
  {

    #region Public Methods

    //string Create(IAggregateRoot item);

    Task<string> CreateAsync(IAggregateRoot item);

    IAggregateRoot FindOne(string id);

    Task<IAggregateRoot> FindOneAsync(string id);

    //IEntity FindOneData(string id);

    //Task<IEntity> FindOneDataAsync(string id);

    //void Remove(string id);

    //Task RemoveAsync(string id);

    //bool Replace(string id, IAggregateRoot item);

    Task<bool> ReplaceAsync(string id, IAggregateRoot item);

    #endregion Public Methods

  }
}