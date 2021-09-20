using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenClosedPrinciple.CombinePercentagesLambda
{
    public class GrossToNetCalculator
    {
        public GrossToNetCalculator(
            IReadOnlyList<double> dependentLosses, 
            IReadOnlyList<double> independentLosses,
            double curtailmentLossGrid,
            Func<double[], double> combinePercentages
            )
        {
            double dependentLoss = 
                combinePercentages(dependentLosses.ToArray());

            double independentLoss =
                combinePercentages(independentLosses.ToArray());

            GrossToNet = 1 - (1 - (dependentLoss + curtailmentLossGrid)) * (1 - independentLoss);
        }

        public double GrossToNet { get; private set; }
    }
}
