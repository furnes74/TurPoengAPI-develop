using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Db.Repository;
using Db.ViewModels;

namespace TurPoengAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;
        private readonly IPersonRepository _personRepo;

        public PersonController(IPersonRepository personRepo, ILogger<PersonController> logger)
        {
            _personRepo = personRepo;
            _logger = logger;
        }

        [HttpGet]
        public PersonVm Get(int id)
        {
            if (id == 0)
            {
                return new PersonVm { 
                    Id = 0
                };
            } else
            {
                return _personRepo.GetPerson(id);
            }
        }
    }
}
