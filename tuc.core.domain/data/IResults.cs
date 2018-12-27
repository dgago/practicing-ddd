using System.Collections.Generic;

public interface IResults<T>
{
  long Count { get; set; }
  uint PageIndex { get; set; }
  uint PageSize { get; set; }
  IEnumerable<T> Items { get; set; }
}