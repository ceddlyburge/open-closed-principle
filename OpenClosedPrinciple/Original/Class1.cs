using System;
using System.Collections.Generic;
using System.Text;

namespace OpenClosedPrinciple.Original
{
    public class GrossToNetCalculator
    {
        public GrossToNetCalculator(
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
            double dependentLoss =
                CombinePercentages(
                    grossYield.TurbineAvailability,
                    grossYield.BalanceAvailability,
                    grossYield.AccessibilityAvailability,
                    hysteresisLoss,
                    electricalLoss,
                    grossYield.EnvironmentalShutdownWeather,
                    grossYield.EnvironmentalSiteAccess,
                    grossYield.EnvironmentTreeGrowth);

            double independentLoss =
                CombinePercentages(
                    grossYield.GridAvailability,
                    turbinePerformanceExperience,
                    turbineLossTurbulence,
                    grossYield.EnvironmentalPerformanceDegradationIcing,
                    grossYield.CurtailmentPowerPurchase,
                    grossYield.SubOptimalPerformance,
                    turbineLossShear,
                    operationalExperienceLoss);

            GrossToNet = 1 - (1 - (dependentLoss + curtailmentLossGrid)) * (1 - independentLoss);
        }

        private double CombinePercentages(object gridAvailability, double turbinePerformanceExperience, double turbineLossTurbulence, object environmentalPerformanceDegradationIcing, object curtailmentPowerPurchase, object subOptimalPerformance, double turbineLossShear, double operationalExperienceLoss)
        {
            throw new NotImplementedException();
        }

        private double CombinePercentages(object turbineAvailability, object balanceAvailability, object accessibilityAvailability, double hysteresisLoss, double electricalLoss, object environmentalShutdownWeather, object environmentalSiteAccess, object environmentTreeGrowth)
        {
            throw new NotImplementedException();
        }

        double CombinePercentages(params double[] percentages)
        {
            double combination = 1;
            foreach (var percentage in percentages)
                combination *= 1 - percentage;
            return 1 - combination;
        }

        public double GrossToNet { get; private set; }
    }
}
