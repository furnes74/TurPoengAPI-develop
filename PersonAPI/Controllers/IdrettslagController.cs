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
    public class IdrettslagController : ControllerBase
    {
        private readonly ILogger<IdrettslagController> _logger;
        private readonly IIdrettslagRepository _idrettslagRepo;

        public IdrettslagController(IIdrettslagRepository repository, ILogger<IdrettslagController> logger)
        {
            _idrettslagRepo = repository;
            _logger = logger;
        }

        [HttpGet]
        public Idrettslag[] Get()
        {
            return _idrettslagRepo.GetIdrettslag();
        }
    }
}
