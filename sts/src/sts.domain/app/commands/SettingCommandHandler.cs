using System;
using System.Threading.Tasks;
using sts.domain.data;
using tuc.core.domain.application;
using tuc.core.domain.services;

namespace sts.domain.app.commands
{

  public abstract class SettingCommandHandler<TCommand> : ICommandHandler<TCommand>
    where TCommand : Command
  {

    #region Protected Fields

    protected readonly ISettingRepository _repository;

    #endregion Protected Fields

    #region Protected Constructors

    protected SettingCommandHandler(ISettingRepository settingRepository)
    {
      _repository = settingRepository
        ?? throw new ArgumentNullException(nameof(settingRepository));
    }

    #endregion Protected Constructors

    #region Public Methods

    public abstract Task<CommandResult> HandleAsync(TCommand command);

    #endregion Public Methods

  }
}