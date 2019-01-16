using System.Threading.Tasks;
using tuc.core.domain.services;

namespace tuc.core.domain.application
{
    public class EventPublisherCommandHandler<TCommand, K> : ICommandHandler<TCommand>
        where TCommand : ItemCommand<K>
        where K : class
    {

        #region Private Fields

        private readonly IEventAdapter _eventAdapter;

        private readonly ICommandHandler<TCommand> _handler;

        #endregion Private Fields

        #region Public Constructors

        public EventPublisherCommandHandler(ICommandHandler<TCommand> handler,
            IEventAdapter eventAdapter)
        {
            _handler = handler;
            _eventAdapter = eventAdapter;
        }

        #endregion Public Constructors

        #region Public Methods

        public async Task<CommandResult> HandleAsync(TCommand command)
        {
            CommandResult res = await _handler.HandleAsync(command)
                .ConfigureAwait(false);

            _eventAdapter.Publish(command.Item.DomainEvents);

            return res;
        }

        #endregion Public Methods

    }
}