using System;
using System.IO;

class Program
{
    static void Main()
    {
        // Читання всіх значень з INPUT.TXT та розділення їх за ";"
        string inputText = File.ReadAllText("INPUT.TXT").Trim();
        string[] numbers = inputText.Split(';');
        
        // Змінна для зберігання результатів
        string outputText = "";

        // Обробка кожного числа
        foreach (string num in numbers)
        {
            int N = int.Parse(num.Trim());
            int count = 0;

            // Підрахунок чисел від 1 до N, які не діляться на 2, 3 або 5
            for (int i = 1; i <= N; i++)
            {
                if (i % 2 != 0 && i % 3 != 0 && i % 5 != 0)
                {
                    count++;
                }
            }

            // Додавання результату у рядок outputText з ";"
            outputText += count + ";";
        }

        // Видалення останньої крапки з комою
        outputText = outputText.TrimEnd(';');

        // Запис результату у OUTPUT.TXT
        File.WriteAllText("OUTPUT.TXT", outputText);

        Console.WriteLine("Результат записано у файл OUTPUT.TXT");
    }
}
