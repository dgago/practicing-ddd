using System;
using Dawn;
using tuc.core.domain.helpers;
using tuc.core.domain.model;
using tuc.fs.domain.model.fileModel.events;

namespace tuc.fs.domain.model.fileModel
{
  public class FileRoot : AggregateRoot<string>
  {
    public string ProviderId { get; }
    public string Container { get; }
    public string Name { get; }
    public string ContentType { get; }
    public byte[] Bytes { get; }
    public int Size { get; }
    public int NumberOfPages { get; private set; }
    public DateTime? UploadDate { get; private set; }
    public string Path { get; private set; }

    public FileRoot(string providerId, string container, string name,
      string contentType, byte[] bytes, DateTime? uploadDate = null,
      string id = null, uint version = 0)
        : base(id, version)
    {
      if (id == null)
      {
        this.Id = GuidFactory.Create().ToString();
      }

      this.ProviderId = Guard.Argument(providerId, nameof(providerId)).NotWhiteSpace();
      this.Container = Guard.Argument(container, nameof(container)).NotWhiteSpace();
      this.Name = Guard.Argument(name, nameof(name)).NotWhiteSpace();
      this.ContentType = Guard.Argument(contentType, nameof(contentType)).NotWhiteSpace();

      this.Bytes = bytes;
      this.Size = bytes.Length;

      CalculatePageCount(contentType, bytes);

      if (IsNew)
      {
        AddEvent(new FileCreatedEvent(this.Id, this.ProviderId, this.Container,
          this.Name, this.ContentType, this.Size, this.NumberOfPages, DateTime.Now));
      }
    }

    internal void SetProviderPath(string path)
    {
      Guard.Argument(this.Path, nameof(this.Path)).Null();
      Guard.Argument(this.UploadDate, nameof(this.UploadDate)).Null();

      this.Path = Guard.Argument(path, nameof(path)).NotWhiteSpace();
      this.UploadDate = DateTime.Now;

      AddEvent(new FileUploadedEvent(this.Id, this.Path, this.UploadDate.Value));
    }

    /// <summary>
    /// Calcula el número de páginas del archivo
    /// </summary>
    /// <param name="contentType"></param>
    /// <param name="bytes"></param>
    private void CalculatePageCount(string contentType, byte[] bytes)
    {
      if (contentType != "application/pdf")
      {
        this.NumberOfPages = 1;
        return;
      }

      iTextSharp.text.pdf.PdfReader reader = null;
      try
      {
        reader = new iTextSharp.text.pdf.PdfReader(bytes);
        this.NumberOfPages = reader.NumberOfPages;
      }
      catch (Exception)
      {
        this.NumberOfPages = 1;
      }
      finally
      {
        if (reader != null)
        {
          reader.Close();
        }
      }
    }
  }
}