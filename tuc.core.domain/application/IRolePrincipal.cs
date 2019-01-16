using System.Security.Principal;

namespace tuc.core.domain.application
{
    public interface IRolePrincipal : IPrincipal
    {

        #region Public Properties

        string[] Roles { get; }

        #endregion Public Properties

    }
}