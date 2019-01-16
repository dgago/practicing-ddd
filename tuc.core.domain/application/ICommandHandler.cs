using System.Threading.Tasks;
using tuc.core.domain.services;

namespace tuc.core.domain.application
{
    public interface ICommandHandler<TCommand>
        where TCommand : Command
    {

        #region Public Methods

        Task<CommandResult> HandleAsync(TCommand command);

        #endregion Public Methods

    }
}