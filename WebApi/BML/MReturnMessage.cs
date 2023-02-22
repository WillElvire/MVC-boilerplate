namespace WebApi.BML;

public class ReturnMessage
{
    public string Message { get; set; }
    public ReturnCode Code { get; set; }
    public Object ReturnObject { get; set; }
}

public enum ReturnCode
{
    OK = 202 ,
    FAILED = 400 , 
    NOT_AUTHENTICATE  = 402
} 