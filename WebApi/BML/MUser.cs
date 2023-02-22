using System.ComponentModel.DataAnnotations;
using WebApi.BML.Interfaces;

namespace WebApi.BML;

public class MUser : IUserAction
{
    [Required]
    public string ID { get; set; }
    [Required]
    public string name { get; set; }
    [Required]
    public string email { get; set; } = string.Empty;

    public ReturnMessage GeneratePassword()
    {
        throw new NotImplementedException();
    }

    public ReturnMessage IsLoggedIn()
    {
        throw new NotImplementedException();
    }

    public int getDayWorked(MEmployee mEmployee)
    {
        return mEmployee.getDayWorked();
    }
}