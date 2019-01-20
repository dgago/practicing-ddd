using tuc.core.domain.model;

namespace tuc.core.domain.data
{
  public abstract class Mapper<TRoot, TData>
    where TRoot : IAggregateRoot
    where TData : IEntity
  {
    #region Public Methods

    public abstract TData MapToData(TRoot item);

    public abstract TRoot MapToDomain(TData item);

    #endregion Public Methods
  }
}