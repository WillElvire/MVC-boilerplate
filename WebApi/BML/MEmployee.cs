using WebApi.BML.Interfaces;

namespace WebApi.BML;

public class MEmployee : IEmployee
{
    private int dayWorked;

    public MEmployee()
    {
        
    }
    public MEmployee(int dayWorked )
    {
        this.dayWorked = dayWorked;
    }
    public int getDayWorked()
    {
        return this.dayWorked;
    }
}