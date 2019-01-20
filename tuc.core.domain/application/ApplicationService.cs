using System;
using System.Threading.Tasks;
using tuc.core.domain.extensions;
using tuc.core.domain.model;
using tuc.core.domain.services.access_control;

namespace tuc.core.domain.application
{
  public class ApplicationService
  {

    #region Protected Methods

    protected void Acl<K>(Command command, IAggregateRoot item)
      where K : class
    {
      if (command.ResourceName.IsNows())
      {
        throw new ArgumentException("No se especifica el recurso a validar.");
      }

      string[] roles = null;
      if (!command.Username.IsNows())
      {
        roles = GetUserRoles();
      }

      bool hasAccess = AccessControlDomainService.HasAccess(
        command.ResourceName,
        command.Username,
        roles,
        item);

      if (!hasAccess)
      {
        throw new UnauthorizedAccessException(command.ResourceName);
      }
    }

    /// <summary>
    /// Publica los eventos de una entidad raíz.
    /// </summary>
    /// <param name="item"></param>
    /// <typeparam name="K"></typeparam>
    /// <returns></returns>
    protected Task PublishAsync(IAggregateRoot item)
    {
      return null;
    }

    #endregion Protected Methods

    #region Private Methods

    private string[] GetUserRoles()
    {
      throw new NotImplementedException();
    }

    #endregion Private Methods

  }
}