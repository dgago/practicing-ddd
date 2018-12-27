using System.Collections.Generic;
using System.Threading.Tasks;
using Dawn;

namespace tuc.fs.domain.services.fileProvider
{
  public abstract class FileProvider
  {
    protected string name { get; set; }
    protected string connectionString { get; set; }
    protected string container { get; set; }

    FileProvider(string name, string connectionString, string container,
      Dictionary<string, string> args)
    {
      this.name = Guard.Argument(name, nameof(name)).NotWhiteSpace();
      this.connectionString = Guard.Argument(
        connectionString,
        nameof(connectionString)
      ).NotWhiteSpace();
      this.container = Guard.Argument(container, nameof(container)).NotWhiteSpace();
    }

    public abstract Task<string> PostAsync(FileProviderModel file);

    public abstract Task<string> DeleteAsync(FileProviderModel file);
  }
}