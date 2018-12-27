public abstract class Mapper<T, D, K>
  where T : Entity<K>
  where D : Entity<K>
  where K : class
{
  public abstract D MapToData(T item);

  public abstract T MapToDomain(D item);
}
