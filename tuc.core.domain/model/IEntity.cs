namespace tuc.core.domain.model
{
  public interface IEntity
  {

    #region Public Properties

    string Id { get; }

    uint Version { get; }

    #endregion Public Properties

    #region Public Methods

    bool Equals(object obj);

    int GetHashCode();

    #endregion Public Methods

  }
}