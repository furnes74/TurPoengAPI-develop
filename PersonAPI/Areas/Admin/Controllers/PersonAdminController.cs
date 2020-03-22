using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Db.Repository;
using Db.Models;

namespace TurPoengAPI.Admin.Controllers
{
    public class PersonAdminController : AdminControllerBase
    {
        private readonly IPersonRepository _personRepo;

        public PersonAdminController(IPersonRepository personRepo, ILogger<AdminControllerBase> logger) : base(logger)
        {
            _personRepo = personRepo;
        }

        [HttpGet("{action}/{id}")]
        public Person GetPerson(int id)
        {
            if (id == 0)
            {
                return new Person { 
                    Id = 0
                };
            } else
            {
                return _personRepo.GetPersonForAdmin(id);
            }
        }
    }
}
