using System.IO;
using Xunit;

public class ProgramTests
{
    public ProgramTests()
    {
        // Очищення або створення файлів перед кожним тестом
        if (File.Exists("INPUT.TXT")) File.Delete("INPUT.TXT");
        if (File.Exists("OUTPUT.TXT")) File.Delete("OUTPUT.TXT");
    }

    [Fact]
    public void TestCountDivisorsMeetingCondition_With12_Returns2()
    {
        int result = Program.CountDivisorsMeetingCondition(12);
        Assert.Equal(2, result); // Прості дільники: 2, 3. Дільники, що діляться на обидва: 6, 12.
    }

    [Fact]
    public void TestCountDivisorsMeetingCondition_With239_Returns1()
    {
        int result = Program.CountDivisorsMeetingCondition(239);
        Assert.Equal(1, result); // 239 - просте число, єдиний дільник, що відповідає умовам, це 239.
    }

    [Fact]
    public void TestCountDivisorsMeetingCondition_With100_Returns3()
    {
        int result = Program.CountDivisorsMeetingCondition(100);
        Assert.Equal(3, result); // Прості дільники: 2, 5. Дільники, що діляться на обидва: 10, 20, 100.
    }

    [Fact]
    public void TestCountDivisorsMeetingCondition_With30_Returns2()
    {
        int result = Program.CountDivisorsMeetingCondition(30);
        Assert.Equal(2, result); // Прості дільники: 2, 3, 5. Дільники, що діляться на всі: 30.
    }

    [Fact]
    public void TestProcessInputAndOutputFiles_WithInputFile12_WritesExpectedOutput()
    {
        // Запис вхідного значення 12 у файл INPUT.TXT
        File.WriteAllText("INPUT.TXT", "12");

        // Запуск методу для обробки вхідного і вихідного файлів
        Program.ProcessInputAndOutputFiles();

        // Читання результату з OUTPUT.TXT
        string output = File.ReadAllText("OUTPUT.TXT").Trim();

        // Перевірка, що результат дорівнює 2
        Assert.Equal("2", output);
    }

    [Fact]
    public void TestProcessInputAndOutputFiles_WithInputFile239_WritesExpectedOutput()
    {
        // Запис вхідного значення 239 у файл INPUT.TXT
        File.WriteAllText("INPUT.TXT", "239");

        // Запуск методу для обробки вхідного і вихідного файлів
        Program.ProcessInputAndOutputFiles();

        // Читання результату з OUTPUT.TXT
        string output = File.ReadAllText("OUTPUT.TXT").Trim();

        // Перевірка, що результат дорівнює 1
        Assert.Equal("1", output);
    }
}
