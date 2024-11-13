using System;
using System.IO;
using Xunit;

public class ProgramTests
{
    private const string InputFilePath = "../INPUT.TXT";
    private const string OutputFilePath = "../OUTPUT.TXT";

    public ProgramTests()
    {
        // Clearing or creating files before each test
        if (File.Exists(InputFilePath)) File.Delete(InputFilePath);
        if (File.Exists(OutputFilePath)) File.Delete(OutputFilePath);
    }

    [Fact]
    public void TestCountDivisorsMeetingCondition_With12_Returns2()
    {
        int result = Program.CountDivisorsMeetingCondition(12);
        Assert.Equal(2, result); // Expected divisors: 6, 12.
    }

    [Fact]
    public void TestCountDivisorsMeetingCondition_With239_Returns1()
    {
        int result = Program.CountDivisorsMeetingCondition(239);
        Assert.Equal(1, result); // 239 is prime, only 239 meets the conditions.
    }

    [Fact]
    public void TestCountDivisorsMeetingCondition_With100_Returns3()
    {
        int result = Program.CountDivisorsMeetingCondition(100);
        Assert.Equal(3, result); // Expected divisors: 10, 20, 100.
    }

    [Fact]
    public void TestCountDivisorsMeetingCondition_With30_Returns2()
    {
        int result = Program.CountDivisorsMeetingCondition(30);
        Assert.Equal(2, result); // Expected divisors: 15, 30.
    }

    [Fact]
    public void TestProcessInputAndOutputFiles_WithInputFile12_WritesExpectedOutput()
    {
        // Write input value 12 to INPUT.TXT
        File.WriteAllText(InputFilePath, "12");

        // Execute method to process input and output files
        Program.ProcessInputAndOutputFiles();

        // Read result from OUTPUT.TXT
        string output = File.ReadAllText(OutputFilePath).Trim();

        // Check that result matches expected output
        Assert.Equal("2", output);
    }

    [Fact]
    public void TestProcessInputAndOutputFiles_WithInputFile239_WritesExpectedOutput()
    {
        // Write input value 239 to INPUT.TXT
        File.WriteAllText(InputFilePath, "239");

        // Execute method to process input and output files
        Program.ProcessInputAndOutputFiles();

        // Read result from OUTPUT.TXT
        string output = File.ReadAllText(OutputFilePath).Trim();

        // Check that result matches expected output
        Assert.Equal("1", output);
    }

    [Fact]
    public void TestProcessInputAndOutputFiles_WithMultipleInputs_WritesExpectedOutput()
    {
        // Write multiple input values to INPUT.TXT
        File.WriteAllText(InputFilePath, "12 239 100 30");

        // Execute method to process input and output files
        Program.ProcessInputAndOutputFiles();

        // Read result from OUTPUT.TXT
        string output = File.ReadAllText(OutputFilePath).Trim();

        // Check that result matches expected output for each input
        Assert.Equal("2 1 3 2", output);
    }
}
