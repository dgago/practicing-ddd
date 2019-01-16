using System.Collections.Generic;
using tuc.core.domain.model;

namespace tuc.core.domain.application
{
    public interface IEventAdapter
    {
        #region Public Methods

        void Publish(IReadOnlyList<DomainEvent> domainEvents);

        #endregion Public Methods
    }
}