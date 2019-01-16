namespace tuc.core.domain.services
{
    public class CommandResult
    {
        #region Public Constructors

        public CommandResult(string id, string message)
        {
            Id = id;
            Message = message;
        }

        public CommandResult(string id)
        {
            Id = id;
        }

        #endregion Public Constructors

        #region Public Properties

        public string Id { get; }

        public string Message { get; }

        #endregion Public Properties
    }
}