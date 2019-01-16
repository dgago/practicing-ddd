using tuc.core.domain.model;

namespace tuc.core.domain.application
{
    public abstract class ItemCommand<K> : Command
        where K : class
    {

        #region Public Properties

        public AggregateRoot<K> Item { get; set; }

        #endregion Public Properties

    }
}