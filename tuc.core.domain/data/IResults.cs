using System;
using System.Collections.Generic;

namespace tuc.core.domain.data
{
  public class Results<T>
  {
    #region Public Constructors

    public Results(long count, IEnumerable<T> items, uint pageIndex, uint pageSize)
    {
      Count = count;
      Items = items;
      PageIndex = pageIndex;
      PageSize = pageSize;
      PageCount = CalculatePageCount(count, pageSize);
    }

    #endregion Public Constructors

    #region Public Properties

    public long Count { get; set; }

    public IEnumerable<T> Items { get; set; }

    public uint PageCount { get; set; }

    public uint PageIndex { get; set; }

    public uint PageSize { get; set; }

    #endregion Public Properties

    #region Protected Methods

    protected uint CalculatePageCount(long count, uint pageSize)
    {
      return (uint)Math.Ceiling((double)count / pageSize);
    }

    #endregion Protected Methods

  }
}