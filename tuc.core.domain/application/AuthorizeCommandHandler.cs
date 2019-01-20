using System;
using System.Threading.Tasks;
using tuc.core.domain.extensions;
using tuc.core.domain.model;
using tuc.core.domain.services;
using tuc.core.domain.services.access_control;

namespace tuc.core.domain.application
{
  public class AuthorizeCommandHandler<TCommand> : ICommandHandler<TCommand>
      where TCommand : ItemCommand
  {

    #region Private Fields

    private readonly ICommandHandler<TCommand> _handler;

    #endregion Private Fields

    #region Public Constructors

    public AuthorizeCommandHandler(
      ICommandHandler<TCommand> handler)
    {
      _handler = handler;
    }

    #endregion Public Constructors

    #region Public Methods

    public async Task<CommandResult> HandleAsync(TCommand command)
    {
      if (command.ResourceName.IsNows())
      {
        throw new ArgumentException("No se especifica el recurso a validar.");
      }

      IAggregateRoot item = null;
      if (_handler is IItemCommandHandler<TCommand> itemHandler)
      {
        item = itemHandler.Repository.FindOne(command.Id);
        item.Exists(item.GetType().Name, command.Id);
        command.Item = item;
      }

      bool hasAccess = AccessControlDomainService.HasAccess(
        command.ResourceName,
        command.Username,
        command.UserRoles,
        command.Item);

      if (!hasAccess)
      {
        // TODO: Audit log

        throw new UnauthorizedAccessException(command.ResourceName);
      }

      return await _handler.HandleAsync(command).ConfigureAwait(false);
    }

    #endregion Public Methods

  }
}