using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Db.Repository;
using Db.ViewModels;

namespace TurPoengAPI.Api.Controllers
{
    public class PersonController : ApiControllerBase
    {
        private readonly IPersonRepository _personRepo;

        public PersonController(IPersonRepository personRepo, ILogger<PersonController> logger) : base(logger)
        {
            _personRepo = personRepo;
        }

        [HttpGet("GetPerson/{id}")]
        public PersonVm GetPerson(int id)
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
