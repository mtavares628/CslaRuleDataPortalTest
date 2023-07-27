using Csla;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataPortalController : Csla.Server.Hosts.HttpPortalController
    {
        public DataPortalController(ApplicationContext applicationContext) : base(applicationContext)
        {
        }
    }
}
