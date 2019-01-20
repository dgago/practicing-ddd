using System.Threading.Tasks;
using sts.domain.data;
using sts.domain.model.settings;
using tuc.core.domain.application;
using tuc.core.domain.services;

namespace sts.domain.app.commands
{
  public class CreateSettingCommand : Command
  {

    #region Public Constructors

    public CreateSettingCommand(string id, object values)
    {
      Id = id;
      Values = values;
    }

    #endregion Public Constructors

    #region Public Properties

    public string Id { get; set; }

    public object Values { get; set; }

    #endregion Public Properties

  }

  public class CreateSettingCommandHandler : SettingCommandHandler<ChangeSettingCommand>
  {

    #region Internal Constructors

    internal CreateSettingCommandHandler(ISettingRepository settingRepository)
      : base(settingRepository)
    {
    }

    #endregion Internal Constructors

    #region Public Methods

    public override async Task<CommandResult> HandleAsync(ChangeSettingCommand command)
    {
      SettingRoot item = new SettingRoot(
        command.Id,
        command.Username,
        command.Values);

      string id = await _repository.CreateAsync(item)
        .ConfigureAwait(false);

      return new CommandResult(id);
    }

    #endregion Public Methods

  }

}