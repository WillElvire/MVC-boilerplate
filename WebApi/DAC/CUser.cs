using WebApi.BML;
using WebApi.DAL;

namespace WebApi.DAC;

public class CUser
{
   
    private AUser _aUser;
    public CUser(string mConnexion)
    {
        _aUser = new AUser(mConnexion);
    }
    public ReturnMessage Create(MUser mUser)
    {
        return _aUser.Create(mUser);
    }
}