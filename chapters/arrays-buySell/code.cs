#region Using statements
using System;
#endregion

namespace BrainCrushers;

public class Exercise
{
#region Intro
    public readonly record struct StockPrice (DateTime Time, double Value);

    public (DateTime Buy, DateTime Sell)? BestBuySellTime(StockPrice[] data)
	{
#endregion
#region Solution
        return null; // Fix me
#endregion
#region Outro
    }
#endregion
}
