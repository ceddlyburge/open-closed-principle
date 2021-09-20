## Create a PercentageCombiner abstraction

This folder shows one possible refactor of the original code, with the aim of analysing the costs and benefits of each.

[GrossToNetCalculator.cs](./GrossToNetCalculator.cs) shows the refactor of the original code.

[TradeOffs.cs](./TradeOffs.cs) shows logic that is removed from `GrossToNetCalculator`, and must now be calculated by the caller
