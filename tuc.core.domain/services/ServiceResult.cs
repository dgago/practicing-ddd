namespace tuc.fs.domain.services
{
  public class ServiceResult<K>
  {
    public K Id { get; }
    public string Message { get; }

    public ServiceResult(K id, string message)
    {
      this.Id = id;
      this.Message = message;
    }
  }

  public class StringServiceResult : ServiceResult<string>
  {
    public StringServiceResult(string id, string message)
      : base(id, message)
    {
    }
  }
}