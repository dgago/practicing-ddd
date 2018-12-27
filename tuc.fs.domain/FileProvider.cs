using System.Collections.Generic;
using System.Threading.Tasks;
using Dawn;

namespace tuc.fs.domain
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

    public abstract Task<string> PostAsync(FileProviderData file);

    public abstract Task<string> DeleteAsync(FileProviderData file);
  }

  public class FileProviderData
  {
    public string Container { get; }
    public string Name { get; }
    public string ContentType { get; }
    public byte[] Bytes { get; }

    public FileProviderData(string container, string name, string contentType,
      byte[] bytes)
    {
      this.Container = Guard.Argument(container, nameof(container)).NotWhiteSpace();
      this.Name = Guard.Argument(name, nameof(name)).NotWhiteSpace();
      this.ContentType = Guard.Argument(contentType, nameof(contentType)).NotWhiteSpace();
      this.Bytes = bytes;
    }
  }
}