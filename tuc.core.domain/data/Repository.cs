using System;
using System.Threading.Tasks;
using tuc.core.domain.model;

namespace tuc.core.domain.data
{
  public abstract class Repository<T, D, K>
    where T : AggregateRoot<K>
    where D : Entity<K>
    where K : class
  {
    protected IStore<D, K> Store { get; private set; }

    protected Mapper<T, D, K> Mapper { get; private set; }

    public virtual async Task<T> FindOneAsync(K id)
    {
      var item = await this.Store.FindOneAsync(id);
      if (item == null)
      {
        return null;
      }

      return this.Mapper.MapToDomain(item);
    }

    public virtual T FindOne(K id)
    {
      var item = this.Store.FindOne(id);
      if (item == null)
      {
        return null;
      }

      return this.Mapper.MapToDomain(item);
    }

    public virtual Task<D> FindOneDataAsync(K id)
    {
      return this.Store.FindOneAsync(id);
    }

    public virtual D FindOneData(K id)
    {
      return this.Store.FindOne(id);
    }

    public virtual Task<K> CreateAsync(T item)
    {
      var ritem = this.Mapper.MapToData(item);
      return this.Store.CreateAsync(ritem);
    }

    public virtual K Create(T item)
    {
      var ritem = this.Mapper.MapToData(item);
      return this.Store.Create(ritem);
    }

    public virtual async Task<bool> ReplaceAsync(K id, T item)
    {
      D ditem = await GetItemAsync(id);

      ValidateItemVersion(item, ditem);

      var ritem = this.Mapper.MapToData(item);
      return await this.Store.ReplaceAsync(id, ritem);
    }

    public virtual bool Replace(K id, T item)
    {
      D ditem = GetItem(id);

      ValidateItemVersion(item, ditem);

      var ritem = this.Mapper.MapToData(item);
      return this.Store.Replace(id, ritem);
    }

    private static void ValidateItemVersion(T item, D ditem)
    {
      if (ditem.Version > item.Version)
      {
        throw new ApplicationException($"El registro a actualizar está obsoleto. Versiones {ditem.Version} <> {item.Version}.");
      }
    }

    private async Task<D> GetItemAsync(K id)
    {
      var ditem = await this.Store.FindOneAsync(id);
      if (ditem == null)
      {
        throw new ApplicationException($"El registro a actualizar no existe.");
      }

      return ditem;
    }

    private D GetItem(K id)
    {
      var ditem = this.Store.FindOne(id);
      if (ditem == null)
      {
        throw new ApplicationException($"El registro a actualizar no existe.");
      }

      return ditem;
    }
  }
}