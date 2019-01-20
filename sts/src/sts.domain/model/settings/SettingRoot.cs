using System;
using sts.domain.model.settings.events;
using tuc.core.domain.model;

namespace sts.domain.model.settings
{
  public sealed class SettingRoot : AggregateRoot
  {
    #region Internal Constructors

    internal SettingRoot(string id, string owner, object values, uint version = 0)
    : base(id, owner, null, version)
    {
      Values = values;

      if (IsNew)
      {
        AddEvent(new SettingCreatedEvent(id.ToString(), values, DateTime.Now));
      }
    }

    #endregion Internal Constructors

    #region Public Properties

    public object Values { get; private set; }

    #endregion Public Properties

    #region Internal Methods

    internal void ChangeValues(object values)
    {
      Values = values;

      AddEvent(new SettingChangedEvent(Id.ToString(), values, DateTime.Now));
    }

    #endregion Internal Methods
  }
}