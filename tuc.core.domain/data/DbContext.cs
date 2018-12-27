using System.Collections.Generic;
using System.Threading.Tasks;

public abstract class DbContext<TClient, TPool, TDb>
{
  public string ConnectionString { get; private set; }

  public abstract Task<TClient> GetClient();

  public abstract Task<TPool> GetPool();

  public abstract Task<TDb> GetDb();

  public abstract Task Release(TClient client);

  public abstract Task Close(bool force = false);
}
