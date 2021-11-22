using ConvertMetricUnits.Core.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ConvertMetricUnits.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeightController : ControllerBase
    {
        private IWeightRepository _repository;
        private readonly ILogger<WeightController> _logger;

        public WeightController(ILogger<WeightController> logger, IWeightRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet("{from}/{to}/{amount}", Name = "GetWeight")]
        public IActionResult GetWeight(string from, string to, int amount)
        {
            if (amount == 0)
                return NotFound();

            return Ok(_repository.ConvertWeight(from, to, amount));
        }
    }
}