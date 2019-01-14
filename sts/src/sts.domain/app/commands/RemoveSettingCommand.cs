using System.Security.Principal;
using tuc.core.domain.application;

namespace sts.domain.app.commands
{
  public class RemoveSettingCommand : Command
  {

    #region Public Constructors

    public RemoveSettingCommand(
      IPrincipal principal, 
      string id)
      : base(principal)
    {
      Id = id;

      ResourceName = "Setting.Remove";
    }

    #endregion Public Constructors

    #region Public Properties

    public string Id { get; set; }

    #endregion Public Properties

  }
}