using System.Threading.Tasks;
using Dawn;
using tuc.core.domain.application;
using tuc.core.domain.model;
using tuc.fs.domain.application.commands;
using tuc.fs.domain.data;
using tuc.fs.domain.model.fileModel;
using tuc.fs.domain.services;
using tuc.fs.domain.services.fileProvider;

namespace tuc.fs.domain.application
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

    public async Task<StringServiceResult> PostFileAsync(PostFileCommand command)
    {
      var fileData = new FileProviderModel(command.Container, command.Name,
        command.ContentType, command.Bytes);

      FileProvider provider = _fileDs.GetProvider(command.ProviderId);
      string path = await provider.PostAsync(fileData);

      FileRoot item = new FileRoot(command.ProviderId, command.Container,
        command.Name, command.ContentType, command.Bytes);
      item.SetProviderPath(path);

      await this._fileRepository.CreateAsync(item);

      await PublishAsync(item);

      return new StringServiceResult(item.Id, null);
    }
  }
}