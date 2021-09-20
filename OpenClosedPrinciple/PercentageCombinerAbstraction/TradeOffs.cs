
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenClosedPrinciple.PercentageCombinerAbstraction
{
    public class TradeOffs
    {
        /*
        In this solution the code has become a lot more open to extension, but the trade off
        is that the calling code now has to know which losses are dependent and which are
        independent, we added a level of abstraction, and we spent a lot of time. This change 
        is very unlikely and the trade off is significant, so this is not a good idea, and 
        it would only make sense to do this when we knew that the change was actually required
        */
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
                new GrossToNetCalculator(
                    dependentLosses,
                    independentLosses,
                    curtailmentLossGrid,
                    new PercentageCombiner())
                .GrossToNet;
        }
    }
}
