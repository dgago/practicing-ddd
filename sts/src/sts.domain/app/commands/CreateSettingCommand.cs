using System.Security.Principal;
using tuc.core.domain.application;

namespace sts.domain.app.commands
{
  public class CreateSettingCommand : Command
  {

    #region Public Constructors

    public CreateSettingCommand(
      IPrincipal principal,
      string id, 
      object values)
      : base(principal)
    {
      Id = id;
      Values = values;

      ResourceName = "Setting.Create";
    }

    #endregion Public Constructors

    #region Public Properties

    public string Id { get; set; }

    public object Values { get; set; }

    #endregion Public Properties

  }
}