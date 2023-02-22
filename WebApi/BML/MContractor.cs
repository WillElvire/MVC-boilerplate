using WebApi.BML.Interfaces;

namespace WebApi.BML;

public class MContractor : IContractor
{
    private int hoursWorked;
    
    public MContractor(int hoursWorked)
    {
        this.hoursWorked = hoursWorked;
    }
    public int getHourWorked()
    {
        return this.hoursWorked;
    }
}