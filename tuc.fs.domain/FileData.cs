using System;

namespace tuc.fs.domain
{
  public class FileData : Entity<String>
  {
    public FileData(string id, uint version) : base(id, version)
    {
    }

    public string Provider { get; set; }

    public string Path { get; set; }

    public string ContentType { get; set; }

    public int Size { get; set; }

    public byte[] Bytes { get; set; }

    public int PageCount { get; set; }

    public DateTime UploadDateUtc { get; set; }
  }
}