using System.Collections.Generic;
using Xunit;
using LTShowcase;

public class InputManager_tests
{
    InputManager manager = new InputManager();
    readonly List<int> expectedOutput = new List<int>() { 2, 3, 5, 7, 8, 9, 10 };

    [Theory]
    [InlineData("2-3, 5, 7-10")]
    [InlineData("2-3, 5, 7-10,")]
    [InlineData(",2-3, 5, 7-10")]
    [InlineData("2- 3, 5, 7 -10")]
    [InlineData("2erw-3, 5,,,,, 7-  f10")]
    public void ParseInput_Should_Equal_expectedOutputList(string input)
    {
        List<int> results = manager.ParseInput(input);
        for (int i = 0; i < expectedOutput.Count; i++)
        {
            Assert.True(results[i].Equals(expectedOutput[i]));
        }
    }
}