using tuc.core.domain.data;
using tuc.fs.domain.model.fileModel;

namespace tuc.fs.domain.data
{
  public class FileRepository : Repository<FileRoot, FileData, string>
  {
    public FileRepository() { }
  }
}