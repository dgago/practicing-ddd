﻿using System;

namespace tuc.core.domain.extensions
{
  public static class ConvertExtensions
  {
    #region Public Methods

    public static DateTime ToDateTime(this object arg)
    {
      if (arg == null)
      {
        return DateTime.MinValue;
      }

      if (arg is DateTime)
      {
        return (DateTime)arg;
      }

      DateTime res;
      DateTime.TryParse(arg.ToString(), out res);
      return res;
    }

    public static int ToInt32(this object arg)
    {
      if (arg == null)
      {
        return 0;
      }

      if (arg is int)
      {
        return (int)arg;
      }

      return Convert.ToInt32(arg);
    }

    public static long ToInt64(this object arg)
    {
      if (arg == null)
      {
        return 0;
      }

      if (arg is long)
      {
        return (long)arg;
      }

      return Convert.ToInt64(arg);
    }

    #endregion Public Methods
  }
}