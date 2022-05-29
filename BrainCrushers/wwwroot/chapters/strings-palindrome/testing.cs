namespace BrainCrushersTests;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class Tester1 : BaseTester
{
    public Tester1() : base(
        new (string Text, bool ExpectedResult)[]
        {
            new ("racecar", true),
            new ("mom", true),
            new ("a", true),
            new ("", true),
            new ("121", true),
            new ("Rotor", false),
            new ("Madam, I'm Adam", false),
            new ("Brain Crushers", false),
        },
        (s) => (new BrainCrushers.Exercise()).IsWordPalindrome(s))
    {
    }
}

public class Tester2 : BaseTester
{
    public Tester2() : base(
        new (string Text, bool ExpectedResult)[]
        {
            new ("racecar", true),
            new ("mom", true),
            new ("a", true),
            new ("", true),
            new ("121", true),
            new ("Rotor", true),
            new ("Madam, I'm Adam", true),
            new ("Brain Crushers", false),
            new ("?!", true),
        },
        (s) => (new BrainCrushers.Exercise()).IsPhrasePalindrome(s))
    {
    }
}

public abstract class BaseTester
{
    protected readonly (string Text, bool ExpectedResult)[] Tests;
    private readonly Func<string, bool> ToBeTested;

    protected BaseTester((string Text, bool ExpectedResult)[] tests, Func<string, bool> toBeTested)
    {
        Tests = tests;
        ToBeTested = toBeTested;
    }

    public async IAsyncEnumerable<string> TestAsync()
    {
        foreach (var test in Tests)
        {
            yield return $"\"{test}\" =>";
            await Task.Yield();

            bool result;
            try
            {
                result = ToBeTested(test.Text);
            }
            catch (Exception e)
            {
                throw new ApplicationException("Error while running test", e);
            }

            bool success = result == test.ExpectedResult;
            yield return $" {result} {(success ? '✓' : '✗')}{Environment.NewLine}";
            if (!success)
            {
                throw new ApplicationException("Invalid test result");
            }
        }
    }
}