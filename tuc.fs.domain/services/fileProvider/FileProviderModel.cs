using Dawn;

namespace tuc.fs.domain.services.fileProvider
{
  public class FileProviderModel
  {
    public string Container { get; }
    public string Name { get; }
    public string ContentType { get; }
    public byte[] Bytes { get; }

    public FileProviderModel(string container, string name, string contentType,
      byte[] bytes)
    {
      this.Container = Guard.Argument(container, nameof(container)).NotWhiteSpace();
      this.Name = Guard.Argument(name, nameof(name)).NotWhiteSpace();
      this.ContentType = Guard.Argument(contentType, nameof(contentType)).NotWhiteSpace();
      this.Bytes = bytes;
    }
  }
}