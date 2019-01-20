using System;
using System.Reflection;
using System.Threading.Tasks;
using SimpleInjector;
using sts.domain.app.commands;
using sts.domain.data;
using tuc.core.domain.application;
using tuc.core.domain.data;
using tuc.core.domain.model;
using tuc.core.domain.services;

namespace sts.test.console
{
  class SettingRepository : ISettingRepository
  {
    public string Create(IAggregateRoot item)
    {
      throw new NotImplementedException();
    }

    public Task<string> CreateAsync(IAggregateRoot item)
    {
      throw new NotImplementedException();
    }

    public IAggregateRoot FindOne(string id)
    {
      throw new NotImplementedException();
    }

    public Task<IAggregateRoot> FindOneAsync(string id)
    {
      throw new NotImplementedException();
    }

    public IEntity FindOneData(string id)
    {
      throw new NotImplementedException();
    }

    public Task<IEntity> FindOneDataAsync(string id)
    {
      throw new NotImplementedException();
    }

    public void Remove(string id)
    {
      throw new NotImplementedException();
    }

    public Task RemoveAsync(string id)
    {
      throw new NotImplementedException();
    }

    public bool Replace(string id, IAggregateRoot item)
    {
      throw new NotImplementedException();
    }

    public Task<bool> ReplaceAsync(string id, IAggregateRoot item)
    {
      throw new NotImplementedException();
    }
  }

  class Program
  {
    static readonly Container container;

    static Program()
    {
      container = new Container();

      //container.Register<ISettingRepository, SettingRepository>(Lifestyle.Singleton);

      // TODO: debería haber una forma de registrar a todos los repository juntos
      Assembly[] assemblies = new[] { typeof(IRepository).Assembly };
      container.Register(typeof(IRepository), assemblies, Lifestyle.Singleton);

      //container.Register<CreateSettingCommandHandler>(Lifestyle.Singleton);
      //container.Register<ChangeSettingCommandHandler>(Lifestyle.Singleton);

      // TODO: debería haber una forma de registrar a todos los command handler juntos
      container.Register(typeof(ICommandHandler<>), typeof(ICommandHandler<>).Assembly, Lifestyle.Singleton);

      container.RegisterDecorator(typeof(ICommandHandler<>),
        typeof(AuthorizeCommandHandler<>));
      container.RegisterDecorator(typeof(ICommandHandler<>),
        typeof(EventPublisherCommandHandler<>));

      container.Verify();
    }

    static void Main(string[] args)
    {
      Console.WriteLine("Hello World!");

      ChangeSettingCommandHandler handler 
        = container.GetInstance<ChangeSettingCommandHandler>();

      const string id = "1";
      ChangeSettingCommand command = new ChangeSettingCommand(id, new { });

      CommandResult res = handler.HandleAsync(command).Result;
    }
  }
}
