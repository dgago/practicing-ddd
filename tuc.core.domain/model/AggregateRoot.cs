using System.Collections.Generic;

namespace tuc.core.domain.model
{
  public abstract class AggregateRoot : Entity, IAggregateRoot
  {

    #region Private Fields

    private readonly List<DomainEvent> _domainEvents = new List<DomainEvent>();

    private readonly List<string> _sharedList = new List<string>();

    #endregion Private Fields

    #region Public Constructors

    public AggregateRoot(
      string id,
      string owner,
      List<string> sharedList = null,
      uint version = 0)
      : base(id, version)
    {
      this.Owner = owner;
      this._sharedList = sharedList ?? new List<string>();
    }

    #endregion Public Constructors

    #region Public Properties

    public virtual IReadOnlyList<DomainEvent> DomainEvents => _domainEvents;

    public string Owner { get; }

    public virtual IReadOnlyList<string> SharedList => _sharedList;

    #endregion Public Properties

    #region Protected Properties

    protected bool IsNew => this.Version <= 0;

    #endregion Protected Properties

    #region Public Methods

    public virtual void ClearEvents()
    {
      _domainEvents.Clear();
    }

    #endregion Public Methods

    #region Protected Methods

    protected void AddEvent(DomainEvent newEvent)
    {
      _domainEvents.Add(newEvent);
    }

    #endregion Protected Methods

  }
}