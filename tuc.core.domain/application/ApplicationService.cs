using System.Threading.Tasks;
using Dawn;
using tuc.core.domain.model;

namespace tuc.core.domain.application
{
  public class ApplicationService
  {
    /// <summary>
    /// Publica los eventos de una entidad raíz.
    /// </summary>
    /// <param name="item"></param>
    /// <typeparam name="K"></typeparam>
    /// <returns></returns>
    protected Task PublishAsync<K>(AggregateRoot<K> item)
      where K : class
    {
      return null;
    }
  }

  public class Command : ValueObject
  {

  }
}