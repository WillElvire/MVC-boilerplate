using WebApi.BML;
using WebApi.DAC;

namespace WebApi.BLL;

public class LUser
{
   
    private CUser _cUser;
    private LCacheManager<MUser> _cacheManager;

    public LUser(LCacheManager<MUser> cacheManager)
    {
        _cacheManager = cacheManager;
    }
    public LUser(string mConnexion)
    {
        _cUser = new(mConnexion);
       
    }
    
    public ReturnMessage Create(MUser mUser)
    {
        return  _cUser.Create(mUser);
    }
}