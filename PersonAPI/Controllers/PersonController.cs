using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Db;
using Db.Models;
using Db.Context;
using Db.Repository;

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
        public Person[] Get()
        {
            return _personRepo.GetPersoner();
        }
    }
}
