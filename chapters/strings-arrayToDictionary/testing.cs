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
        foreach (var data in new IReadOnlyList<string>[]
            {
                new List<string> {  "[Brain]=Crushers", "[I]=💗", "[foo]=bar" }.AsReadOnly(),
                new List<string> { }.AsReadOnly(),
            })
        {
            yield return $"{PrintStringList(data)} =>";
            await Task.Yield();

            Dictionary<string, string> result;
            try
            {
                BrainCrushers.Exercise exercise = new();
                result = exercise.ToDictionary(data);
            }
            catch (Exception e)
            {
                throw new ApplicationException("Error while running test", e);
            }

            bool success = result?.Select(kvp => $"[{kvp.Key}]={kvp.Value}").OrderBy(s => s).SequenceEqual(data.OrderBy(s => s)) ?? false;
            yield return $" {PrintStringDictionary(result)} {(success ? '✓' : '✗')}{Environment.NewLine}";
            if (!success)
            {
                throw new ApplicationException("Invalid test result");
            }
        }
    }

    private string PrintStringList(IEnumerable<string>? data)
        => data is null ? "null" : "[" + string.Join(", ", data.Select(PrintString)) + "]";

    private string PrintStringDictionary(Dictionary<string, string>? data)
        => data is null ? "null" : "{" + string.Join(", ", data.Select(t => $"[{PrintString(t.Key)}] = {PrintString(t.Value)}")) + "}";

    private string PrintString(string? s)
        => s is null ? "null" : @"""" + s + @"""";
}