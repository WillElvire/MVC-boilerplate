using Microsoft.Extensions.Caching.Memory;
using WebApi.BML;

namespace WebApi.BLL;

public class LCacheManager<T>
{
  private IMemoryCache cache;
  private  string cachekey;
  
  LCacheManager(string cacheKey, IMemoryCache cache)
  {
    this.cachekey = cachekey;
  }
  
  public LCacheManager<T> setCacheKey(string cacheKey)
  {
    this.cachekey = cachekey;
    return this;
  }

  public string getCacheKey()
  {
    return this.cachekey;
  }
  public ReturnMessage AddToCache(T data)
  {
    ReturnMessage message = new ReturnMessage();
    try
    {
      cache.Set(this.cachekey, data, this.SetCacheOption());
      message.Code = ReturnCode.OK;
    }
    catch (Exception e)
    {
      message.Message = "Erreur dans la fonction d'ajout a cache" + e.Message;
      message.Code = ReturnCode.FAILED;
    }

    return message;

  }

  public ReturnMessage GetCache()
  {
    ReturnMessage message = new ReturnMessage();
    try
    {
      message.ReturnObject =  cache.TryGetValue(cachekey, out IEnumerable<T> data);
      message.Code = ReturnCode.OK;
    }
    catch (Exception e)
    {
      message.Message = "Erreur lors de la recuperation des informations" + e.Message;
      message.Code = ReturnCode.FAILED;
    }

    return message;
  }
  
  public ReturnMessage GetCache(string cacheKey)
  {
    ReturnMessage message = new ReturnMessage();
    try
    {
      message.ReturnObject =  cache.TryGetValue(cacheKey, out IEnumerable<T> data);
      message.Code = ReturnCode.OK;
    }
    catch (Exception e)
    {
      message.Message = "Erreur lors de la recuperation des informations" + e.Message;
      message.Code = ReturnCode.FAILED;
    }

    return message;
  }

  private MemoryCacheEntryOptions SetCacheOption()
  {
    var cache = new MemoryCacheEntryOptions();
    cache.SetSlidingExpiration(TimeSpan.FromSeconds(45));
    cache.SetPriority(CacheItemPriority.High);
    cache.SetAbsoluteExpiration(TimeSpan.FromSeconds(3600));
    return cache;

  }
}