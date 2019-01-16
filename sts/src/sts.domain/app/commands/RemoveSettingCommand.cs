using tuc.core.domain.application;

namespace sts.domain.app.commands
{
  public class RemoveSettingCommand : Command
  {

    #region Public Constructors

    public RemoveSettingCommand(
      string id)
    {
      Id = id;
    }

    #endregion Public Constructors

    #region Public Properties

    public string Id { get; set; }

    #endregion Public Properties

  }
}