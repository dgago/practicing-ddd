using tuc.core.domain.application;

namespace sts.domain.app.commands
{
    public class CreateSettingCommand : Command
    {

        #region Public Constructors

        public CreateSettingCommand(string id, object values)
        {
            Id = id;
            Values = values;
        }

        #endregion Public Constructors

        #region Public Properties

        public string Id { get; set; }

        public object Values { get; set; }

        #endregion Public Properties

    }
}