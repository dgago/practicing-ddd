using System;
using sts.domain.model.settings.events;
using tuc.core.domain.model;

namespace sts.domain.model.settings
{
  internal class SettingRoot : AggregateRoot<string>
  {
    #region Internal Constructors

    internal SettingRoot(string id, string owner, object values, uint version = 0)
    : base(id, owner, null, version)
    {
      Values = values;

      if (IsNew)
      {
        AddEvent(new SettingCreatedEvent(id, values, DateTime.Now));
      }
    }

    #endregion Internal Constructors

    #region Public Properties

    public object Values { get; private set; }

    #endregion Public Properties

    #region Internal Methods

    internal void ChangeValues(object values)
    {
      this.Values = values;

      AddEvent(new SettingChangedEvent(this.Id, values, DateTime.Now));
    }

    #endregion Internal Methods
  }
}