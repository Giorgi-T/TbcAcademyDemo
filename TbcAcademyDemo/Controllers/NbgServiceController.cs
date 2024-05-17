using Microsoft.AspNetCore.Mvc;
using TbcAcademyDemo.Services;

namespace TbcAcademyDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NbgServiceController : ControllerBase
    {
        private readonly INbgService _ngbService;

        public NbgServiceController(INbgService ngbService)
        {
            _ngbService = ngbService;
        }

        [HttpGet("GetNbgRates")]
        public async Task<ActionResult<string>> GetNbgRates(CancellationToken cancellationToken)
        {
            return  await _ngbService.GetRates(cancellationToken);
        }
    }
}
