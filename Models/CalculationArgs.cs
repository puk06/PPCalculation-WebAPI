namespace PPCalculationAPI.Models;

internal struct CalculationArgs
{
    internal int Mode { get; set; }
    internal int Mods { get; set; }
    internal int Combo { get; set; }
    internal double Accuracy { get; set; }
    internal int HitGeki { get; set; }
    internal int Hit300 { get; set; }
    internal int HitKatu { get; set; }
    internal int Hit100 { get; set; }
    internal int Hit50 { get; set; }
    internal int HitMiss { get; set; }
    internal int Score { get; set; }
}
