using tuc.core.domain.application;

namespace tuc.fs.domain.application.commands
{
  public class PostFileCommand : Command
  {
    #region Public Constructors

    public PostFileCommand() { }

    public PostFileCommand(string client, string username, string providerId,
      string container, string name, string contentType, byte[] bytes)
      : base(client, username)
    {
      ProviderId = providerId;
      Container = container;
      Name = name;
      ContentType = contentType;
      Bytes = bytes;
    }

    #endregion Public Constructors

    #region Public Properties

    public byte[] Bytes { get; set; }

    public string Container { get; set; }

    public string ContentType { get; set; }

    public string Name { get; set; }

    public string ProviderId { get; set; }

    #endregion Public Properties
  }
}