using System;
using tuc.core.domain.model;

namespace sts.domain.model.settings.events
{
  internal class SettingCreatedEvent : DomainEvent
  {
    #region Internal Constructors

    internal SettingCreatedEvent(string id, object values, DateTime createdDate)
        : base(createdDate)
    {
      Id = id;
      Values = values;
    }

    #endregion Internal Constructors

    #region Public Properties

    public string Id { get; }

    public object Values { get; }

    #endregion Public Properties
  }
}