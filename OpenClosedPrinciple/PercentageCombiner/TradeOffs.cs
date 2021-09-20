
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenClosedPrinciple.PercentageCombiner
{
    public class TradeOffs
    {
        // In this solution the code has become a lot more open to extension, but the trade off
        // is that the calling code now has to know which losses are dependent and which are 
        // independent, we added a level of abstraction, and we spent a reasonable amount of
        // time. This change is unlikely and the trade off is significant, so this is probably 
        // not a good idea. If there was another use case for the PercentageCombiner function
        // then it would make more sense.
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


            var grossToNet = 
                new GrossToNetCalculator(dependentLosses, independentLosses, curtailmentLossGrid)
                .GrossToNet;
        }
    }
}
