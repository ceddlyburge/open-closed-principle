
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenClosedPrinciple.CombinePercentagesLambda
{
    public class TradeOffs
    {
        // In this solution the code has become a lot more open to extension, but the trade off
        // is that the calling code now has to know which losses are dependent and which are 
        // independent, and how to combine percentages. This change is very unlikely and the loss
        // of encapsulation is extreme, so this is not a good idea.
        public TradeOffs(
            IGrossEnergyYield grossYield,
            double grossEnergy,
            double hysteresisLoss,
            double curtailmentLossGrid,
            double turbineLossTurbulence,
            double electricalLoss,
            double turbineLossShear,
            double turbinePerformanceExperience,
            double operationalExperienceLoss)
        {
            var dependentLosses = new List<double> {
                grossYield.TurbineAvailability,
                grossYield.BalanceAvailability,
                grossYield.AccessibilityAvailability,
                hysteresisLoss,
                electricalLoss,
                grossYield.EnvironmentalShutdownWeather,
                grossYield.EnvironmentalSiteAccess,
                grossYield.EnvironmentTreeGrowth
            };

            var independentLosses = new List<double> {
                grossYield.GridAvailability,
                turbinePerformanceExperience,
                turbineLossTurbulence,
                grossYield.EnvironmentalPerformanceDegradationIcing,
                grossYield.CurtailmentPowerPurchase,
                grossYield.SubOptimalPerformance,
                turbineLossShear,
                operationalExperienceLoss
            };


            Func<double[], double> combinePercentages = 
                (double[] percentages) =>
                {
                    double combination = 1;
                    foreach (var percentage in percentages)
                        combination *= 1 - percentage;
                    return 1 - combination;
                };

            var grossToNet = 
                new GrossToNetCalculator(
                    dependentLosses,
                    independentLosses,
                    curtailmentLossGrid, 
                    combinePercentages)
                .GrossToNet;
        }
    }
}
