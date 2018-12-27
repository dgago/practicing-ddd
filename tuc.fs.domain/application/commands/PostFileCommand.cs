using tuc.core.domain.application;
using tuc.core.domain.model;

namespace tuc.fs.domain.application.commands
{
  public class PostFileCommand : Command
  {
    public string ProviderId { get; set; }
    public string Container { get; set; }
    public string Name { get; set; }
    public string ContentType { get; set; }
    public byte[] Bytes { get; set; }

    PostFileCommand() { }

    PostFileCommand(string providerId, string container,
      string name, string contentType, byte[] bytes)
    {
      ProviderId = providerId;
      Container = container;
      Name = name;
      ContentType = contentType;
      Bytes = bytes;
    }
  }
}