using System.Collections.Generic;

namespace tuc.core.domain.model
{
  public interface IAggregateRoot : IEntity
  {

    #region Public Properties

    IReadOnlyList<DomainEvent> DomainEvents { get; }

    string Owner { get; }

    IReadOnlyList<string> SharedList { get; }

    #endregion Public Properties

    #region Public Methods

    void ClearEvents();

    #endregion Public Methods

  }
}