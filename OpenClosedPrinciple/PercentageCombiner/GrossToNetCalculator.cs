using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenClosedPrinciple.PercentageCombiner
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
                PercentageCombiner.CombinePercentages(dependentLosses.ToArray());

            double independentLoss =
                PercentageCombiner.CombinePercentages(independentLosses.ToArray());

            GrossToNet = 1 - (1 - (dependentLoss + curtailmentLossGrid)) * (1 - independentLoss);
        }

        public double GrossToNet { get; private set; }
    }
}
