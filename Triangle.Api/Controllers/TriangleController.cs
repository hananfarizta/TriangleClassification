using Microsoft.AspNetCore.Mvc;
using Triangle.Domain.Dto;
using Triangle.Domain.Services.Interfaces;

namespace Triangle.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TriangleController : Controller
    {
        private readonly ITriangleService triangleService;

        public TriangleController(ITriangleService triangleService)
        {
            this.triangleService = triangleService;
        }

        [HttpGet]
        [Route("style")]
        public IActionResult GetStyle([FromQuery] TriangleDto triangle)
        {
            try
            {
                var style = triangleService.GetStyle(triangle.FirstSide, triangle.SecondSide, triangle.ThirdSide);

                if (style == null)
                {
                    return NotFound("Triangle style not found");
                }

                return Ok(style);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }
    }
}
