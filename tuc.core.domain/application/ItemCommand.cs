using tuc.core.domain.model;

namespace tuc.core.domain.application
{
  public abstract class ItemCommand : Command
  {

    #region Public Constructors

    public ItemCommand(string id)
    {
      Id = id;
    }

    #endregion Public Constructors

    #region Public Properties

    public string Id { get; set; }

    public IAggregateRoot Item { get; internal set; }

    #endregion Public Properties

  }
}