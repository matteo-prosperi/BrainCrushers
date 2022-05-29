namespace BrainCrushersTests;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class Tester1
{
    public async IAsyncEnumerable<string> TestAsync()
    {
        foreach (var test in new (string Word1, string Word2, bool ExpectedResult)[]
            {
                ("listen", "silent", true),
                ("Listen", "Silent", true),
                ("The morse code", "Here come dots...", true),
                ("Braincrushers", "Braincrushers", true),
                ("I", "i", true),
                ("", "", true),
                ("Twelve plus one", "Eleven plus two", true),
                ("Braincrusher!", "Braincrushers", false),
                ("listen", "silents", false),
            })
        {
            yield return $"\"{test.Word1}\", \"{test.Word2}\" =>";
            await Task.Yield();

            bool result;
            try
            {
                BrainCrushers.Exercise exercise = new();
                result = exercise.AreAnagrams(test.Word1, test.Word2);
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

public class Tester2
{
    public async IAsyncEnumerable<string> TestAsync()
    {
        foreach (var test in new (string[] Words, bool ExpectedResult)[]
            {
                (new string[] { "listen", "silent" }, true),
                (new string[] { "Listen", "Silent", "Enlist!" }, true),
                (new string[] { "Braincrushers", "Braincrushers" }, true),
                (new string[] { "Braincrushers" }, true),
                (new string[] { "" }, true),
                (new string[] { "Braincrusher!", "Braincrushers" }, false),
                (new string[] { "listen", "silents" }, false),
                (new string[] { "Twelve plus one", "Eleven plus two" }, true),
                (new string[] { "Twelve plus one", "Eleven plus two", "Ten plus three" }, false),
                (new string[] { "Twelve plus one", "Ten plus three", "Eleven plus two" }, false),
            })
        {
            yield return $"[{string.Join(", ", test.Words.Select(w => $"\"{w}\""))}] =>";
            await Task.Yield();

            bool result;
            try
            {
                BrainCrushers.Exercise exercise = new();
                result = exercise.AreAnagrams(test.Words);
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

public class Tester3
{
    public async IAsyncEnumerable<string> TestAsync()
    {
        foreach (var test in new (string Word1, string Word2, bool ExpectedResult)[]
            {
                ("listen", "silent", true),
                ("the morse code", "here come dots", true),
                ("Braincrushers", "Braincrushers", true),
                ("Braincrushers", "braincrushers", false),
                ("Braincrushers?", "Braincrushers!", false),
                ("I", "I", true),
                ("I", "i", false),
                ("", "", true),
                ("Twelve Plus one", "eleven Plus Two", true),
                ("dormitory", "dirty room", false),
                ("bursa dağı", "su bardağı", true),
            })
        {
            yield return $"\"{test.Word1}\", \"{test.Word2}\" =>";
            await Task.Yield();

            bool result;
            try
            {
                BrainCrushers.Exercise exercise = new();
                result = exercise.AreAnagrams2(test.Word1, test.Word2);
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