namespace WebApi.BML.Interfaces;

public interface IUserAction
{
    public ReturnMessage GeneratePassword();
    public ReturnMessage IsLoggedIn();
}