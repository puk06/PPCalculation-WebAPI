using osu.Game.Rulesets;
using osu.Game.Rulesets.Mods;
using osu.Game.Rulesets.Osu.Mods;
using PPCalculationAPI.Models;

namespace PPCalculationAPI.Utils;

internal class ModsUtils
{
    private static Mod[] GetMods(Ruleset ruleset, string[] modsString)
    {
        if (modsString.Length == 0) return [.. ruleset.CreateAllMods().Where(m => m is OsuModClassic)];
        var availableMods = ruleset.CreateAllMods();

        IEnumerable<Mod> mods = [];

        foreach (var modString in modsString)
        {
            var mod = availableMods.FirstOrDefault(m => string.Equals(m.Acronym, modString, StringComparison.CurrentCultureIgnoreCase));
            if (mod != null)
            {
                mods = mods.Append(mod);
            }
        }

        mods = mods.Append(new OsuModClassic());


        return [.. mods];
    }

    internal static Mod[] GetModsWithNum(Ruleset ruleset, CalculationArgs args)
        => GetMods(ruleset, ModsParser(args.Mods));

    private static readonly Dictionary<int, string> ModToStrings = new()
    {
        { 0, "NM" },
        { 1, "NF" },
        { 2, "EZ" },
        { 8, "HD" },
        { 16, "HR" },
        { 32, "SD" },
        { 64, "DT" },
        { 128, "RX" },
        { 256, "HT" },
        { 512, "NC" },
        { 1024, "FL" },
        { 2048, "Autoplay" },
        { 8192, "Relax2" },
        { 16384, "PF" }
    };

    private static string[] ModsParser(int mods)
    {
        var activeMods = new List<string>();

        for (int i = 0; i < 14; i++)
        {
            int bit = 1 << i;
            if ((mods & bit) == bit && ModToStrings.TryGetValue(bit, out string? value))
            {
                activeMods.Add(value);
            }
        }

        if (activeMods.Contains("DT") && activeMods.Contains("NC"))
        {
            activeMods.Remove("DT");
        }

        return [.. activeMods];
    }
}