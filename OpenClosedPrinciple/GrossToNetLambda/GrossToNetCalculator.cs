using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenClosedPrinciple.GrossToNetLambda
{
    public class GrossToNetCalculator
    {
        public GrossToNetCalculator(
            IReadOnlyList<double> dependentLosses, 
            IReadOnlyList<double> independentLosses,
            Func<double, double, double> grossToNetCalculator
            )
        {
            double dependentLoss = 
                CombinePercentages(dependentLosses.ToArray());

            double independentLoss =
                CombinePercentages(independentLosses.ToArray());

            GrossToNet = grossToNetCalculator(dependentLoss, independentLoss);
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
