using System.IO;
using Xunit;

public class ProgramTests
{
    public ProgramTests()
    {
        // Очищення файлів перед кожним тестом
        if (File.Exists("INPUT.TXT")) File.Delete("INPUT.TXT");
        if (File.Exists("OUTPUT.TXT")) File.Delete("OUTPUT.TXT");
    }

    [Fact]
    public void TestCountNumbersNotDivisibleBy235_With10_Returns2()
    {
        int result = Program.CountNumbersNotDivisibleBy235(10);
        Assert.Equal(2, result);
    }

    [Fact]
    public void TestCountNumbersNotDivisibleBy235_With20_Returns6()
    {
        int result = Program.CountNumbersNotDivisibleBy235(20);
        Assert.Equal(6, result);
    }

    [Fact]
    public void TestCountNumbersNotDivisibleBy235_With1_Returns1()
    {
        int result = Program.CountNumbersNotDivisibleBy235(1);
        Assert.Equal(1, result);
    }

    [Fact]
    public void TestCountNumbersNotDivisibleBy235_With100_Returns27()
    {
        int result = Program.CountNumbersNotDivisibleBy235(100);
        Assert.Equal(27, result);
    }

    [Fact]
    public void TestProcessInputAndOutputFiles_WithInputFile_WritesExpectedOutput()
    {
        // Підготовка вхідного файлу
        File.WriteAllText("INPUT.TXT", "10;20");

        // Виконання основного методу
        Program.ProcessInputAndOutputFiles();

        // Читання результату з вихідного файлу
        string output = File.ReadAllText("OUTPUT.TXT").Trim();

        // Перевірка результату
        Assert.Equal("2;6", output);
    }
}
