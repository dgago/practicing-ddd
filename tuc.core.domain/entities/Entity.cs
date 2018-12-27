using System;
using Dawn;
using tuc.core.domain.helpers;

public abstract class Entity<K>
  where K : class
{
  public virtual K Id { get; protected set; }

  public uint Version { get; protected set; }

  public Entity(K id, uint version = 0)
  {
    if (id == null)
    {
      Guard.Argument(version, nameof(version)).Zero();
    }

    this.Id = id;
    this.Version = version;
  }

  public override bool Equals(object obj)
  {
    var other = obj as Entity<K>;

    if (ReferenceEquals(other, null))
      return false;

    if (ReferenceEquals(this, other))
      return true;

    if (GetType() != other.GetType())
      return false;

    if (Id == null || other.Id == null)
      return false;

    return Id == other.Id;
  }

  public static bool operator ==(Entity<K> a, Entity<K> b)
  {
    if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
      return true;

    if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
      return false;

    return a.Equals(b);
  }

  public static bool operator !=(Entity<K> a, Entity<K> b)
  {
    return !(a == b);
  }

  public override int GetHashCode()
  {
    return (GetType().Name + Id).GetHashCode();
  }

  // private Type GetRealType()
  // {
  //   return NHibernateProxyHelper.GetClassWithoutInitializingProxy(this);
  // }
}