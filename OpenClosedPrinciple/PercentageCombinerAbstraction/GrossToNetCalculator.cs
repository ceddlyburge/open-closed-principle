using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenClosedPrinciple.PercentageCombinerAbstraction
{
    public class GrossToNetCalculator
    {
        public GrossToNetCalculator(
            IReadOnlyList<double> dependentLosses,
            IReadOnlyList<double> independentLosses,
            double curtailmentLossGrid,
            IPercentageCombiner percentageCombiner
            )
        {
            double dependentLoss =
                percentageCombiner.CombinePercentages(dependentLosses.ToArray());

            double independentLoss =
                percentageCombiner.CombinePercentages(independentLosses.ToArray());

            GrossToNet = 1 - (1 - (dependentLoss + curtailmentLossGrid)) * (1 - independentLoss);
        }

        public double GrossToNet { get; private set; }
    }
}
