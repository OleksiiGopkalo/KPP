using System;
using System.IO;

public class Program // Зробіть клас публічним
{
    public static void Main()
    {
        ProcessInputAndOutputFiles();
    }

    public static void ProcessInputAndOutputFiles() // Зробіть метод публічним
    {
        // Читання даних з INPUT.TXT
        string inputText = File.ReadAllText("INPUT.TXT").Trim();
        string[] numbers = inputText.Split(';');
        string outputText = "";

        foreach (string num in numbers)
        {
            int N = int.Parse(num.Trim());
            int count = CountNumbersNotDivisibleBy235(N);
            outputText += count + ";";
        }

        // Видалення зайвої крапки з комою і запис у файл OUTPUT.TXT
        outputText = outputText.TrimEnd(';');
        File.WriteAllText("OUTPUT.TXT", outputText);
    }

    public static int CountNumbersNotDivisibleBy235(int N) // Зробіть метод публічним
    {
        int count = 0;
        for (int i = 1; i <= N; i++)
        {
            if (i % 2 != 0 && i % 3 != 0 && i % 5 != 0)
            {
                count++;
            }
        }
        return count;
    }
}
