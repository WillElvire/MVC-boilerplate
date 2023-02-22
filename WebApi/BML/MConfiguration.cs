namespace WebApi.BML;

public class MConfiguration
{
    public string ConnexionString { get; set; }
    private static MConfiguration INSTANCE  {get; set; }
    private MConfiguration()
    {
        
    }

    public static MConfiguration getInstance()
    {
        if (INSTANCE is not null)
        {
            return INSTANCE;
        }

        return INSTANCE = new MConfiguration();
    }

}