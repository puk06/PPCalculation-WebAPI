namespace PPCalculationAPI.Models;

public class CalculationArgs
{
    public string FilePath { get; set; } = string.Empty;
    public int Mode { get; set; }
    public int Mods { get; set; }
    public double Accuracy { get; set; }
    public int Combo { get; set; }
    public int HitGeki { get; set; }
    public int Hit300 { get; set; }
    public int HitKatu { get; set; }
    public int Hit100 { get; set; }
    public int Hit50 { get; set; }
    public int HitMiss { get; set; }
}
