namespace OpenClosedPrinciple.Original
{
    public interface IGrossEnergyYield
    {
        object BalanceAvailability { get; }
        object AccessibilityAvailability { get; }
        object EnvironmentalShutdownWeather { get; }
        object EnvironmentalSiteAccess { get; }
        object EnvironmentTreeGrowth { get; }
        object EnvironmentalPerformanceDegradationIcing { get; }
        object CurtailmentPowerPurchase { get; }
        object SubOptimalPerformance { get; }
        object GridAvailability { get; }
        object TurbineAvailability { get; }
    }
}