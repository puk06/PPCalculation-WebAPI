using osu.Game.Rulesets.Scoring;
using PPCalculationAPI.Models;

namespace PPCalculationAPI.Utils;

internal class HitsUtils
{
    public static Dictionary<HitResult, int> GenerateHitResult(CalculationArgs calculationArgs, int mode)
    {
        return mode switch
        {
            0 => new Dictionary<HitResult, int>
            {
                { HitResult.Great, calculationArgs.Hit300 },
                { HitResult.Ok, calculationArgs.Hit100 },
                { HitResult.Meh, calculationArgs.Hit50 },
                { HitResult.Miss, calculationArgs.HitMiss }
            },
            1 => new Dictionary<HitResult, int>
            {
                { HitResult.Great, calculationArgs.Hit300 },
                { HitResult.Ok, calculationArgs.Hit100 },
                { HitResult.Miss, calculationArgs.HitMiss }
            },
            2 => new Dictionary<HitResult, int>
            {
                { HitResult.Great, calculationArgs.Hit300 },
                { HitResult.LargeTickHit, calculationArgs.Hit100 },
                { HitResult.SmallTickHit, calculationArgs.Hit50 },
                { HitResult.SmallTickMiss, calculationArgs.HitKatu },
                { HitResult.Miss, calculationArgs.HitMiss }
            },
            3 => new Dictionary<HitResult, int>
            {
                { HitResult.Perfect, calculationArgs.HitGeki },
                { HitResult.Great, calculationArgs.Hit300 },
                { HitResult.Good, calculationArgs.HitKatu },
                { HitResult.Ok, calculationArgs.Hit100 },
                { HitResult.Meh, calculationArgs.Hit50 },
                { HitResult.Miss, calculationArgs.HitMiss }
            },
            _ => throw new ArgumentException("Invalid mode provided. Given mode: " + mode)
        };
    }
}