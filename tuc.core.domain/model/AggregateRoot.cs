using System.Collections.Generic;

namespace tuc.core.domain.model
{
  public abstract class AggregateRoot<K> : Entity<K>
    where K : class
  {
    private readonly List<DomainEvent> _domainEvents = new List<DomainEvent>();

    protected bool IsNew => this.Version <= 0;

    public AggregateRoot(K id, uint version = 0) : base(id, version)
    {
    }

    public virtual IReadOnlyList<DomainEvent> DomainEvents => _domainEvents;

    protected virtual void AddEvent(DomainEvent newEvent)
    {
      _domainEvents.Add(newEvent);
    }

    public virtual void ClearEvents()
    {
      _domainEvents.Clear();
    }
  }
}