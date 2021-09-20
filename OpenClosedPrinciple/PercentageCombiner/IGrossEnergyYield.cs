namespace OpenClosedPrinciple.PercentageCombiner
{
    public interface IGrossEnergyYield
    {
        double BalanceAvailability { get; }
        double AccessibilityAvailability { get; }
        double EnvironmentalShutdownWeather { get; }
        double EnvironmentalSiteAccess { get; }
        double EnvironmentTreeGrowth { get; }
        double EnvironmentalPerformanceDegradationIcing { get; }
        double CurtailmentPowerPurchase { get; }
        double SubOptimalPerformance { get; }
        double GridAvailability { get; }
        double TurbineAvailability { get; }
    }
}