namespace WebApi.BML;

public class MContractorAdapter : MEmployee
{
    private MContractor _mContractor;
    
    public MContractorAdapter(MContractor mcontractor)
    {
        _mContractor = mcontractor;
    }
    public MContractorAdapter(int dayWorked) : base(dayWorked)
    {
    }

    public int getDayWorked()
    {
        return this._mContractor.getHourWorked() * 2000;
    }
}