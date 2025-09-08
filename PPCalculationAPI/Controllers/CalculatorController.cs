using Microsoft.AspNetCore.Mvc;
using PPCalculationAPI.Models;
using PPCalculationAPI.PPCalculation;

namespace PPCalculationAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class CalculateController(ILogger<CalculateController> logger) : ControllerBase
{
    private readonly ILogger<CalculateController> _logger = logger;

    [HttpPost]
    public IActionResult Post([FromBody] CalculationArgs args)
    {
        double pp = 0.0;
        double stars = 0.0;

        try
        {
            _logger.LogInformation("Calculation started at {Time}", DateTime.Now);

            var calculationResult = PPCalculator.Calculate(args);
            pp = calculationResult.Item2.Total;
            stars = calculationResult.Item1.StarRating;

            _logger.LogInformation("Calculation finished at {Time}. PP={PP}, Stars={Stars}",
                DateTime.Now, pp, stars);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Calculation failed at {Time}", DateTime.Now);
        }

        return Ok(new CalculationResponse
        {
            Pp = pp,
            Stars = stars
        });
    }
}