using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace TurPoengAPI.Api.Controllers
{
    [ApiController]
    [Area("api")]
    [Route("api/[controller]")]
    public class ApiControllerBase : ControllerBase
    {
        protected readonly ILogger<ApiControllerBase> _logger;
        
        public ApiControllerBase(ILogger<ApiControllerBase> logger)
        {
            _logger = logger;
        }
    }
}
