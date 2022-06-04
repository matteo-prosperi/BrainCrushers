namespace BrainCrushersTests;

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;

public class Tester1 : Tester
{
    public IAsyncEnumerable<string> TestAsync()
        => TestAsync(l => 
           {
               BrainCrushers.Exercise exercise = new();
               return exercise.FilterAlphaNum(l);
           });
}

public class Tester2 : Tester
{
    public IAsyncEnumerable<string> TestAsync()
        => TestAsync(l => 
           {
               BrainCrushers.Exercise exercise = new();
               var newList = l.ToList();
               exercise.FilterAlphaNum2(newList);
               return newList;
           });
}

public class Tester
{
    public static Action? TimeoutCheckAction { get; set; }

    protected async IAsyncEnumerable<string> TestAsync(Func<IReadOnlyList<string>, List<string>> tester)
    {
        foreach (var data in new IReadOnlyList<string>[]
            {
                new string[] { "foo", "I💗BrainCrushers", "baz", "f00b4r" }.ToImmutableArray(),
                ImmutableArray<string>.Empty ,
                new string[] { "f001" }.ToImmutableArray(),
                new string[] { "foo_bar", "foo:bar", "foobar" }.ToImmutableArray(),
            })
        {
            yield return $"{PrintStringList(data)} =>";
            await Task.Yield();

            IList<string> result;
            try
            {
                result = tester(data);
            }
            catch (Exception e)
            {
                throw new ApplicationException("Error while running test", e);
            }

            bool success = result?.SequenceEqual(data.Where(s => s.All(c => char.IsLetterOrDigit(c)))) ?? false;
            yield return $" {PrintStringList(result)} {(success ? '✓' : '✗')}{Environment.NewLine}";
            if (!success)
            {
                throw new ApplicationException("Invalid test result");
            }
        }
    }

    private string PrintStringList(IEnumerable<string>? data)
        => data is null ? "null" : "[" + string.Join(", ", data.Select(t => t is null ? "null" : @"""" + t + @"""")) + "]";
}