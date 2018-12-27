using System.Threading.Tasks;
using Dawn;

namespace tuc.fs.domain
{
  public class FileApplicationService : ApplicationService
  {
    readonly FileRepository _fileRepository;
    readonly FileProviderDomainService _fileDs;

    public FileApplicationService(FileRepository fileRepository,
      FileProviderDomainService fileDs)
    {
      this._fileRepository = Guard.Argument(fileRepository, nameof(fileRepository)).NotNull();
      this._fileDs = Guard.Argument(fileDs, nameof(fileDs)).NotNull();
    }

    public async Task<StringServiceResult> PostFileAsync(string providerId,
      string container, string name, string contentType, byte[] bytes)
    {
      FileProvider provider = _fileDs.GetProvider(providerId);

      FileRoot item = new FileRoot(providerId, container, name,
        contentType, bytes);

      var fileData = new FileProviderData(container, name, contentType, bytes);
      var path = await provider.PostAsync(fileData);

      item.SetProviderPath(path);

      // TODO: esto podría ser parte del handler del evento
      // pero cómo haría para obtener el identificador del archivo
      var id = await this._fileRepository.CreateAsync(item);

      // TODO: commit events

      return new StringServiceResult(item.Id, null);
    }
  }
}