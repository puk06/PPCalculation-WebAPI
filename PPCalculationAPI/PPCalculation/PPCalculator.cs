using osu.Game.Beatmaps;
using osu.Game.Rulesets;
using osu.Game.Rulesets.Difficulty;
using osu.Game.Rulesets.Mods;
using osu.Game.Scoring;
using PPCalculationAPI.Models;
using PPCalculationAPI.Utils;

namespace PPCalculationAPI.PPCalculation;

internal static class PPCalculator
{
    internal static (DifficultyAttributes, PerformanceAttributes) Calculate(CalculationArgs calculationArgs)
    {
        Ruleset ruleset = RulesetUtils.GetRuleset(calculationArgs.Mode);
        Mod[] mods = ModsUtils.GetModsWithNum(ruleset, calculationArgs);

        ProcessorWorkingBeatmap workingBeatmap = ProcessorWorkingBeatmap.FromFile(calculationArgs.FilePath);
        IBeatmap beatmap = workingBeatmap.GetPlayableBeatmap(ruleset.RulesetInfo, mods);

        ScoreInfo scoreInfo = new(beatmap.BeatmapInfo, ruleset.RulesetInfo)
        {
            Accuracy = calculationArgs.Accuracy,
            MaxCombo = calculationArgs.Combo,
            Statistics = HitsUtils.GenerateHitResult(calculationArgs, calculationArgs.Mode),
            Mods = mods
        };

        DifficultyCalculator difficultyCalculator = ruleset.CreateDifficultyCalculator(workingBeatmap);
        DifficultyAttributes difficultyAttributes = difficultyCalculator.Calculate(mods);

        PerformanceCalculator performanceCalculator = ruleset.CreatePerformanceCalculator();
        PerformanceAttributes performanceAttributes = performanceCalculator.Calculate(scoreInfo, difficultyAttributes);

        return (difficultyAttributes, performanceAttributes);
    }
}
