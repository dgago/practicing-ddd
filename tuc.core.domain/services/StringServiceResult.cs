namespace tuc.fs.domain.services
{
  public class StringServiceResult : ServiceResult<string>
  {
    public StringServiceResult(string id, string message)
      : base(id, message)
    {
    }
  }
}