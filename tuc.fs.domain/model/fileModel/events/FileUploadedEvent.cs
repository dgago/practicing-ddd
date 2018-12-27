using System;
using tuc.core.domain.model;

namespace tuc.fs.domain.model.fileModel.events
{
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