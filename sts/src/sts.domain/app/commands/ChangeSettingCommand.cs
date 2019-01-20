using System.Threading.Tasks;
using sts.domain.data;
using sts.domain.model.settings;
using tuc.core.domain.application;
using tuc.core.domain.extensions;
using tuc.core.domain.services;

namespace sts.domain.app.commands
{
  public class ChangeSettingCommand : ItemCommand
  {

    #region Public Constructors

    public ChangeSettingCommand(string id, object values): base (id)
    {
      Values = values;
    }

    #endregion Public Constructors

    #region Public Properties

    public object Values { get; set; }

    #endregion Public Properties

  }

  public class ChangeSettingCommandHandler : SettingCommandHandler<ChangeSettingCommand>
  {

    #region Internal Constructors

    internal ChangeSettingCommandHandler(ISettingRepository settingRepository)
      : base(settingRepository)
    {
    }

    #endregion Internal Constructors

    #region Public Methods

    public override async Task<CommandResult> HandleAsync(ChangeSettingCommand command)
    {
      SettingRoot item = (SettingRoot)command.Item;

      item.ChangeValues(command.Values);

      await _repository.ReplaceAsync(command.Id, item)
        .ConfigureAwait(false);

      return new CommandResult(item.Id);
    }

    #endregion Public Methods

  }
}