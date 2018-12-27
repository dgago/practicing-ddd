using System;
using System.Collections.Generic;

public abstract class DomainEvent : ValueObject
{
  public DomainEvent(DateTime date)
  {
    this.Date = date;
  }

  public DateTime Date { get; }
}