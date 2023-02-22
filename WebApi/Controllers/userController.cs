using Microsoft.AspNetCore.Mvc;
using WebApi.BLL;
using WebApi.BML;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class userController : ControllerBase
{

    private LUser _lUser;
    private readonly string cacheKey = "AppCacheKey";

    public userController(LCacheManager<MUser> cache)
    {
        _lUser  = new LUser(MConfiguration.getInstance().ConnexionString);
    }
        
    [HttpPost] 
    public IActionResult Create(MUser mUser)
    {
        MContractor contractor = new MContractor(45);
        MContractorAdapter contractorAdapter = new MContractorAdapter(contractor);
        MUser user = new MUser();
        if (contractorAdapter.GetType() == typeof(MEmployee))
        {
            
        }
        user.getDayWorked(contractorAdapter);
        
        ReturnMessage message = new ReturnMessage();
        try
        {
            message = _lUser.Create(mUser);
            return Ok(message);
        }
        catch (Exception e)
        {
            return NotFound("Erreur dans la fonction" + e.Message);
        }
    }

    [Route("/{id}")]
    [HttpGet]
    public IActionResult GetUserById(string id)
    {
        try
        {
            return Ok();
        }
        catch (Exception e)
        {
            return NotFound();
        }
    }

    [HttpGet]
    public IActionResult GetUserList()
    {
        try
        {
            return Ok();
        }
        catch (Exception e)
        {
            return NotFound();
        }
    }

   
}