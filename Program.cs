using System;

namespace Lab06
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;
            // рівень А: облік балів студентів
            Console.WriteLine("=== Облік балів студентів групи ===");
            Console.WriteLine("Уведіть бали (від 1 до 100). Для завершення введіть 0.");

            const int PassMark = 60;
            const int MaxAllowed = 100;

            int markCount = 0;
            int failCount = 0;
            int totalSum = 0;
            int maxMark = int.MinValue;
            int minMark = int.MaxValue;

            while (true)
            {
                Console.Write($"Бал студента {markCount + 1}: ");
                string input = Console.ReadLine();

                // перевірка коректності введення
                if (!int.TryParse(input, out int mark))
                {
                    Console.WriteLine("Помилка: введіть ціле число.");
                    continue;
                }

                if (mark == 0) { break; }

                if (mark < 0 || mark > MaxAllowed)
                {
                    Console.WriteLine("Помилка: бал має бути від 0 до 100.");
                    continue;
                }

                markCount++;
                totalSum += mark;
                if (mark > maxMark) { maxMark = mark; }
                if (mark < minMark) { minMark = mark; }
                if (mark < PassMark) { failCount++; }
            }

            Console.WriteLine();

            if (markCount == 0)
            {
                Console.WriteLine("Жодної оцінки не введено, звіт порожній.");
            }
            else
            {
                double average = (double)totalSum / markCount;
                double successPercent = (double)(markCount - failCount) / markCount * 100;

                Console.WriteLine($"Кількість оцінок: {markCount}");
                Console.WriteLine($"Середній бал: {average:F1}");
                Console.WriteLine($"Найвищий бал: {maxMark}");
                Console.WriteLine($"Найнижчий бал: {minMark}");
                Console.WriteLine($"Незадовільних оцінок (< {PassMark}): {failCount}");
                Console.WriteLine($"Відсоток успішності: {successPercent:F1} %");
            }

            // РІВЕНЬ Б
            Console.WriteLine();
            int n;
            bool isValid;
            do
            {
                Console.Write("Введіть сторону квадрата n (від 3 до 20): ");
                isValid = int.TryParse(Console.ReadLine(), out n);
                if (!isValid || n < 3 || n > 20)
                {
                    Console.WriteLine("Помилка: потрібне ціле число від 3 до 20.");
                    isValid = false;
                }
            }
            while (!isValid);           // do while цикл

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    char symbol;
                    if (i == j || i + j == n - 1)
                    {
                        symbol = '#';
                    }
                    else if (i == 0 || i == n - 1 || j == 0 || j == n - 1)
                    {
                        symbol = '*';
                    }
                    else
                    {
                        symbol = ' ';
                    }
                    Console.Write(symbol);
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}