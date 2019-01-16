using System;
using System.Threading.Tasks;
using sts.domain.data;
using sts.domain.model.settings;
using tuc.core.domain.application;
using tuc.core.domain.services;

namespace sts.domain.app.commands
{
    public class ChangeSettingCommand : ItemCommand<string>
    {

        #region Public Constructors

        public ChangeSettingCommand(string id, object values)
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

    internal class ChangeSettingCommandHandler : SettingCommandHandler<ChangeSettingCommand>
    {

        #region Internal Constructors

        internal ChangeSettingCommandHandler(ISettingRepository settingRepository) 
            : base(settingRepository)
        {
        }

        #endregion Internal Constructors

        #region Public Methods

        public override async Task<CommandResult> HandleAsync(ChangeSettingCommand command)
        {
            SettingRoot item = await _settingRepository.FindOneAsync(command.Id)
                .ConfigureAwait(false);

            if (item == null)
            {
                throw new ApplicationException("La configuración a actualizar no existe");
            }

            item.ChangeValues(command.Values);

            await _settingRepository.ReplaceAsync(command.Id, item)
                .ConfigureAwait(false);

            return new CommandResult(item.Id);
        }

        #endregion Public Methods

    }
}