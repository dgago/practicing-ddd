using System.Security.Principal;
using tuc.core.domain.model;

namespace tuc.core.domain.application
{
  public class Command : ValueObject
  {
    #region Private Fields

    private readonly IPrincipal _principal;

    #endregion Private Fields

    #region Public Constructors

    public Command(IPrincipal principal)
    {
      _principal = principal;
    }

    #endregion Public Constructors

    #region Public Properties

    public string Username
    {
      get
      {
        return _principal.Identity.Name;
      }
    }

    #endregion Public Properties

    #region Protected Internal Properties

    protected internal string ResourceName { get; protected set; }

    #endregion Protected Internal Properties
  }
}