using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace TurPoengAPI.Admin.Controllers
{
    [ApiController]
    [Area("admin")]
    [Route("admin/[controller]")]
    public class AdminControllerBase : ControllerBase
    {
        protected readonly ILogger<AdminControllerBase> _logger;
        
        public AdminControllerBase(ILogger<AdminControllerBase> logger)
        {
            _logger = logger;
        }
    }
}
