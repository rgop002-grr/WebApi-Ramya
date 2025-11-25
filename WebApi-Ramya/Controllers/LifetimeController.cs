using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi_Ramya.Services_Lifetime;

namespace WebApi_Ramya.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LifetimeController : ControllerBase
    {
        private readonly IOperationSingleton _singleton;
        private readonly IOperationScoped _scoped;
        private readonly IOperationTransient _transient1;
        private readonly IOperationTransient _transient2;

        public LifetimeController(
            IOperationSingleton singleton,
            IOperationScoped scoped,
            IOperationTransient transient1,
            IOperationTransient transient2)
        {
            _singleton = singleton;
            _scoped = scoped;
            _transient1 = transient1;
            _transient2 = transient2;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new
            {
                Singleton = _singleton.OperationId,
                Scoped = _scoped.OperationId,
                Transient1 = _transient1.OperationId,
                Transient2 = _transient2.OperationId
            });
        }
    }

}

