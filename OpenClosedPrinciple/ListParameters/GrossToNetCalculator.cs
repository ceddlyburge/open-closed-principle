using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenClosedPrinciple.ListParameters
{
    public class GrossToNetCalculator
    {
        public GrossToNetCalculator(
            IReadOnlyList<double> dependentLosses, 
            IReadOnlyList<double> independentLosses,
            double curtailmentLossGrid
            )
        {
            double dependentLoss =
                CombinePercentages(dependentLosses.ToArray());

            double independentLoss =
                CombinePercentages(independentLosses.ToArray());

            GrossToNet = 1 - (1 - (dependentLoss + curtailmentLossGrid)) * (1 - independentLoss);
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
