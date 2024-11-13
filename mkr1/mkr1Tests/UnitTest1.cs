using System.IO;
using Xunit;

public class ProgramTests
{
    public ProgramTests()
    {
        // Очищення або створення файлів перед кожним тестом
        if (File.Exists("../INPUT.TXT")) File.Delete("../INPUT.TXT");
        if (File.Exists("../OUTPUT.TXT")) File.Delete("../OUTPUT.TXT");
    }

    [Fact]
    public void TestCountDivisorsMeetingCondition_WithPrimeNumber_Returns0()
    {
        // Прості числа не мають відповідних дільників, результат повинен бути 0
        int result = Program.CountDivisorsMeetingCondition(7);
        Assert.Equal(0, result);
    }

    [Fact]
    public void TestCountDivisorsMeetingCondition_WithSmallCompositeNumber_ReturnsCorrectCount()
    {
        // Число 4 має лише один відповідний дільник, 2
        int result = Program.CountDivisorsMeetingCondition(4);
        Assert.Equal(1, result); // Дільник 2 відповідає умовам
    }

    [Fact]
    public void TestCountDivisorsMeetingCondition_WithCompositeNumber_ReturnsCorrectCount()
    {
        // Число 6 має один відповідний дільник, 3
        int result = Program.CountDivisorsMeetingCondition(6);
        Assert.Equal(1, result); // Дільник 3 відповідає умовам
    }

    [Fact]
    public void TestProcessInputAndOutputFiles_WithSingleInput_WritesExpectedOutput()
    {
        // Вхідний файл з одним числом 8
        File.WriteAllText("../INPUT.TXT", "8");
        Program.ProcessInputAndOutputFiles();
        string output = File.ReadAllText("../OUTPUT.TXT").Trim();
        Assert.Equal("1", output); // Число 8 має один відповідний дільник, 2
    }

    [Fact]
    public void TestProcessInputAndOutputFiles_WithTwoInputs_WritesExpectedOutput()
    {
        // Вхідний файл з двома числами 10 і 12
        File.WriteAllText("../INPUT.TXT", "10 12");
        Program.ProcessInputAndOutputFiles();
        string output = File.ReadAllText("../OUTPUT.TXT").Trim();
        Assert.Equal("0 2", output); // 10 - жодного відповідного дільника, 12 має два (3, 6)
    }
}
