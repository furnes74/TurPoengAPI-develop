using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Db.Models;
using Db.Repository;

namespace TurPoengAPI.Api.Controllers
{
    public class IdrettslagController : ApiControllerBase
    {
        private readonly IIdrettslagRepository _idrettslagRepo;

        public IdrettslagController(IIdrettslagRepository repository, ILogger<IdrettslagController> logger) : base(logger)
        {
            _idrettslagRepo = repository;
        }

        [HttpGet]
        public Idrettslag[] Get()
        {
            return _idrettslagRepo.GetIdrettslag();
        }
    }
}
