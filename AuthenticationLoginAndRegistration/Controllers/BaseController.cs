using AuthenticationLoginAndRegistration.Contracts;
using AuthenticationLoginAndRegistration.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationLoginAndRegistration.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
   
        
    }
}
