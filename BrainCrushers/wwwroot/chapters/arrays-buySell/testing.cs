namespace BrainCrushersTests;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class Tester
{
    public static Action? TimeoutCheckAction { get; set; }

    public async IAsyncEnumerable<string> TestAsync()
    {
        foreach (var data in new (BrainCrushers.Exercise.StockPrice[] Values, (DateTime Buy, DateTime Sell)? ExpectedResult)[]
            {
                (new BrainCrushers.Exercise.StockPrice[]
                {
                    new(new DateTime(1982, 05, 08), 12.1),
                    new(new DateTime(1982, 05, 10), 14.0),
                    new(new DateTime(1982, 05, 11), 11.1),
                    new(new DateTime(1982, 05, 12), 13.3),
                    new(new DateTime(1982, 05, 13), 15.4),
                    new(new DateTime(1982, 05, 14), 17.1),
                    new(new DateTime(1982, 05, 15), 10.2),
                    new(new DateTime(1982, 05, 17), 10.2),
                }, (new DateTime(1982, 05, 11), new DateTime(1982, 05, 14))),
                (new BrainCrushers.Exercise.StockPrice[]
                {
                    new(new DateTime(1982, 05, 08), 12.1),
                    new(new DateTime(1982, 05, 10), 13.0),
                    new(new DateTime(1982, 05, 11), 15.1),
                    new(new DateTime(1982, 05, 12), 17.3),
                }, (new DateTime(1982, 05, 08), new DateTime(1982, 05, 12))),
                (new BrainCrushers.Exercise.StockPrice[]
                {
                    new(new DateTime(1982, 05, 08), 17.1),
                    new(new DateTime(1982, 05, 10), 15.0),
                    new(new DateTime(1982, 05, 11), 14.3),
                    new(new DateTime(1982, 05, 12), 14.1),
                }, null),
                (new BrainCrushers.Exercise.StockPrice[]
                {
                    new(new DateTime(1982, 05, 08), 17.1),
                    new(new DateTime(1982, 05, 10), 18.0),
                    new(new DateTime(1982, 05, 11), 11.1),
                    new(new DateTime(1982, 05, 12), 13.3),
                    new(new DateTime(1982, 05, 13), 15.4),
                    new(new DateTime(1982, 05, 14), 15.3),
                    new(new DateTime(1982, 05, 15), 11.2),
                    new(new DateTime(1982, 05, 17), 10.2),
                }, (new DateTime(1982, 05, 11), new DateTime(1982, 05, 13))),
                (new BrainCrushers.Exercise.StockPrice[]
                {
                    new(new DateTime(1982, 05, 08), 17.1),
                }, null),
                (new BrainCrushers.Exercise.StockPrice[] { }, null),
            })
        {
            yield return $"{PrintArray(data.Values)} =>";
            await Task.Yield();

            (DateTime Buy, DateTime Sell)? result;
            try
            {
                BrainCrushers.Exercise exercise = new();
                result = exercise.BestBuySellTime(data.Values);
            }
            catch (Exception e)
            {
                throw new ApplicationException("Error while running test", e);
            }

            bool success = result == data.ExpectedResult;
            yield return $" {(result is null ? "null" : $"Buy=May {result.Value.Buy.Day}th, Sell=May {result.Value.Sell.Day}th")} {(success ? '✓' : '✗')}{Environment.NewLine}";
            if (!success)
            {
                throw new ApplicationException("Invalid test result");
            }
        }
    }

    protected static string PrintArray(BrainCrushers.Exercise.StockPrice[] data)
        => "[" + string.Join(", ", data.Select(x => ($"May {x.Time.Day}th: ${x.Value}"))) + "]";
}