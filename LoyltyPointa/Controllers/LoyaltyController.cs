using LoyltyPointa.Repo.GravityService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoyltyPointa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoyaltyController : ControllerBase
    {
        private readonly GravityService _gravityService;

        public LoyaltyController(GravityService gravityService)
        {
            _gravityService = gravityService;
        }
        [HttpPost]
        public async Task<ActionResult> GenerateToken()
        {
            var tokenData =  await _gravityService.GetOrGenerateToken();
            return Ok(tokenData);
        }
    }
}
