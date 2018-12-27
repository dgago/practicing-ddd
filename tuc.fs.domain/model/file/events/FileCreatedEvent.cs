using System;

namespace tuc.fs.domain
{
  internal class FileCreatedEvent : DomainEvent
  {
    public string Id { get; }
    public string ProviderId { get; }
    public string Container { get; }
    public string Name { get; }
    public string ContentType { get; }
    public int Size { get; }
    public int NumberOfPages { get; }

    public FileCreatedEvent(string id, string providerId, string container,
      string name, string contentType, int size, int numberOfPages,
      DateTime createdDate) : base(createdDate)
    {
      this.Id = providerId;
      this.Container = container;
      this.Name = name;
      this.ContentType = contentType;
      this.Size = size;
      this.NumberOfPages = numberOfPages;
    }
  }

  internal class FileUploadedEvent : DomainEvent
  {
    public string Id { get; }
    public string Path { get; }

    public FileUploadedEvent(string id, string path, DateTime uploadDate)
      : base(uploadDate)
    {
      this.Path = path;
      this.Id = id;
    }
  }
}