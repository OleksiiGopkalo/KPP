using System;
using System.Collections.Generic;
using System.IO;

public class Program
{
    public static void Main()
    {
        ProcessInputAndOutputFiles();
    }

    public static void ProcessInputAndOutputFiles()
    {
        // Читання чисел з ../INPUT.TXT (на рівень вище)
        string inputText = File.ReadAllText("../INPUT.TXT").Trim();
        string[] numbers = inputText.Split(' ');

        List<string> results = new List<string>();

        foreach (string number in numbers)
        {
            long x = long.Parse(number);
            int count = CountDivisorsMeetingCondition(x);
            results.Add(count.ToString());
        }

        // Запис результатів у ../OUTPUT.TXT (на рівень вище)
        File.WriteAllText("../OUTPUT.TXT", string.Join(" ", results));
    }

    public static int CountDivisorsMeetingCondition(long x)
    {
        List<long> primeFactors = GetPrimeFactors(x);
        List<long> divisors = GetDivisors(x);

        int count = 0;

        foreach (long divisor in divisors)
        {
            bool divisibleByAllPrimes = true;
            foreach (long prime in primeFactors)
            {
                if (divisor % prime != 0)
                {
                    divisibleByAllPrimes = false;
                    break;
                }
            }

            if (divisibleByAllPrimes)
            {
                count++;
            }
        }

        return count;
    }

    public static List<long> GetPrimeFactors(long n)
    {
        List<long> factors = new List<long>();
        for (long i = 2; i * i <= n; i++)
        {
            while (n % i == 0)
            {
                if (!factors.Contains(i))
                {
                    factors.Add(i);
                }
                n /= i;
            }
        }
        if (n > 1)
        {
            factors.Add(n);
        }
        return factors;
    }

    public static List<long> GetDivisors(long n)
    {
        List<long> divisors = new List<long>();
        for (long i = 1; i * i <= n; i++)
        {
            if (n % i == 0)
            {
                divisors.Add(i);
                if (i != n / i)
                {
                    divisors.Add(n / i);
                }
            }
        }
        return divisors;
    }
}
