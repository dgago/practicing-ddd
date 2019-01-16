using System;
using System.Threading.Tasks;
using tuc.core.domain.extensions;
using tuc.core.domain.services;
using tuc.core.domain.services.access_control;

namespace tuc.core.domain.application
{
    public class AuthorizeCommandHandler<TCommand, K> : ICommandHandler<TCommand> 
        where TCommand : ItemCommand<K>
        where K : class
    {

        #region Private Fields

        private readonly ICommandHandler<TCommand> _handler;

        #endregion Private Fields

        #region Public Constructors

        public AuthorizeCommandHandler(ICommandHandler<TCommand> handler)
        {
            _handler = handler;
        }

        #endregion Public Constructors

        #region Public Methods

        public Task<CommandResult> HandleAsync(TCommand command)
        {
            if (command.ResourceName.IsNows())
            {
                throw new ArgumentException("No se especifica el recurso a validar.");
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

            return _handler.HandleAsync(command);
        }

        #endregion Public Methods

    }
}