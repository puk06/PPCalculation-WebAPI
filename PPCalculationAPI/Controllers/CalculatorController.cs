using Microsoft.AspNetCore.Mvc;
using osu.Game.Rulesets.Catch.Difficulty;
using osu.Game.Rulesets.Difficulty;
using osu.Game.Rulesets.Mania.Difficulty;
using osu.Game.Rulesets.Osu.Difficulty;
using osu.Game.Rulesets.Taiko.Difficulty;
using PPCalculationAPI.Models;
using PPCalculationAPI.PPCalculation;

namespace PPCalculationAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculateController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post([FromBody] CalculationArgs args)
        {

            try
            {
                var calculationResult = PPCalculator.Calculate(args);

                switch (args.Mode)
                {
                    case 0:
                        {
                            var difficultyAttributes = (OsuDifficultyAttributes)calculationResult.Item1;
                            var performanceAttributes = (OsuPerformanceAttributes)calculationResult.Item2;

                            var result = new
                            {
                                performance = new
                                {
                                    pp = performanceAttributes.Total,
                                    pp_acc = performanceAttributes.Accuracy,
                                    pp_aim = performanceAttributes.Aim,
                                    pp_speed = performanceAttributes.Speed,
                                    pp_flashlight = performanceAttributes.Flashlight,
                                    effective_miss_count = performanceAttributes.EffectiveMissCount,
                                    pp_difficulty = 0,
                                },
                                difficulty = new
                                {
                                    stars = difficultyAttributes.StarRating,
                                    aim = difficultyAttributes.AimDifficulty,
                                    speed = difficultyAttributes.SpeedDifficulty,
                                    flashlight = difficultyAttributes.FlashlightDifficulty,
                                    slider_factor = difficultyAttributes.SliderFactor,
                                    speed_note_count = difficultyAttributes.SpeedNoteCount,
                                    stamina = 0,
                                    color = 0,
                                    rhythm = 0,
                                    peak = 0
                                }
                            };

                            return Ok(result);
                        }

                    case 1:
                        {
                            var difficultyAttributes = (TaikoDifficultyAttributes)calculationResult.Item1;
                            var performanceAttributes = (TaikoPerformanceAttributes)calculationResult.Item2;

                            var result = new
                            {
                                performance = new
                                {
                                    pp = performanceAttributes.Total,
                                    pp_acc = performanceAttributes.Accuracy,
                                    pp_aim = 0,
                                    pp_speed = 0,
                                    pp_flashlight = 0,
                                    effective_miss_count = 0,
                                    pp_difficulty = performanceAttributes.Difficulty,
                                },
                                difficulty = new
                                {
                                    stars = difficultyAttributes.StarRating,
                                    aim = 0,
                                    speed = 0,
                                    flashlight = 0,
                                    slider_factor = 0,
                                    speed_note_count = 0,
                                    stamina = 0,
                                    color = 0,
                                    rhythm = 0,
                                    peak = 0
                                }
                            };

                            return Ok(result);
                        }

                    case 2:
                        {
                            var difficultyAttributes = (CatchDifficultyAttributes)calculationResult.Item1;
                            var performanceAttributes = (CatchPerformanceAttributes)calculationResult.Item2;

                            var result = new
                            {
                                performance = new
                                {
                                    pp = performanceAttributes.Total,
                                    pp_acc = 0,
                                    pp_aim = 0,
                                    pp_speed = 0,
                                    pp_flashlight = 0,
                                    effective_miss_count = 0,
                                    pp_difficulty = 0,
                                },
                                difficulty = new
                                {
                                    stars = difficultyAttributes.StarRating,
                                    aim = 0,
                                    speed = 0,
                                    flashlight = 0,
                                    slider_factor = 0,
                                    speed_note_count = 0,
                                    stamina = 0,
                                    color = 0,
                                    rhythm = 0,
                                    peak = 0
                                }
                            };

                            return Ok(result);
                        }

                    case 3:
                        {
                            var difficultyAttributes = (ManiaDifficultyAttributes)calculationResult.Item1;
                            var performanceAttributes = (ManiaPerformanceAttributes)calculationResult.Item2;

                            var result = new
                            {
                                performance = new
                                {
                                    pp = performanceAttributes.Total,
                                    pp_acc = 0,
                                    pp_aim = 0,
                                    pp_speed = 0,
                                    pp_flashlight = 0,
                                    effective_miss_count = 0,
                                    pp_difficulty = 0,
                                },
                                difficulty = new
                                {
                                    stars = difficultyAttributes.StarRating,
                                    aim = 0,
                                    speed = 0,
                                    flashlight = 0,
                                    slider_factor = 0,
                                    speed_note_count = 0,
                                    stamina = 0,
                                    color = 0,
                                    rhythm = 0,
                                    peak = 0
                                }
                            };

                            return Ok(result);
                        }

                    default:
                        {
                            var result = new
                            {
                                performance = new
                                {
                                    pp = 0,
                                    pp_acc = 0,
                                    pp_aim = 0,
                                    pp_speed = 0,
                                    pp_flashlight = 0,
                                    effective_miss_count = 0,
                                    pp_difficulty = 0,
                                },
                                difficulty = new
                                {
                                    stars = 0,
                                    aim = 0,
                                    speed = 0,
                                    flashlight = 0,
                                    slider_factor = 0,
                                    speed_note_count = 0,
                                    stamina = 0,
                                    color = 0,
                                    rhythm = 0,
                                    peak = 0
                                }
                            };

                            return Ok(result);

                        }
                }
            }
            catch
            {
                var result = new
                {
                    performance = new
                    {
                        pp = 0,
                        pp_acc = 0,
                        pp_aim = 0,
                        pp_speed = 0,
                        pp_flashlight = 0,
                        effective_miss_count = 0,
                        pp_difficulty = 0,
                    },
                    difficulty = new
                    {
                        stars = 0,
                        aim = 0,
                        speed = 0,
                        flashlight = 0,
                        slider_factor = 0,
                        speed_note_count = 0,
                        stamina = 0,
                        color = 0,
                        rhythm = 0,
                        peak = 0
                    }
                };

                return Ok(result);
            }
        }
    }
}