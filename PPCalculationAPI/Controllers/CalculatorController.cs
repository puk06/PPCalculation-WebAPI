using Microsoft.AspNetCore.Mvc;
using PPCalculationAPI.Models;
using PPCalculationAPI.PPCalculation;
using System.Diagnostics;

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

        Stopwatch sw = Stopwatch.StartNew();
        _logger.LogInformation("Calculation for {id} started", args.FilePath);

        try
        {
            var calculationResult = PPCalculator.Calculate(args);
            pp = calculationResult.Item2.Total;
            stars = calculationResult.Item1.StarRating;

            sw.Stop();
            _logger.LogInformation("Calculation finished! | Calculation took: {Time}ms", sw.ElapsedMilliseconds);
        }
        catch (Exception ex)
        {
            sw.Stop();
            _logger.LogError(ex, "Calculation failed... | Calculation took: {Time}ms", sw.ElapsedMilliseconds);
        }

        return Ok(new CalculationResponse
        {
            Pp = pp,
            Stars = stars
        });
    }
}