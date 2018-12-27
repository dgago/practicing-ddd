using System.Collections.Generic;

namespace tuc.core.domain.data
{
  public interface IResults<T>
  {
    long Count { get; set; }

    uint PageIndex { get; set; }

    uint PageSize { get; set; }

    IEnumerable<T> Items { get; set; }
  }
}