//******************************************
//* Практичсекая работа № 10               *
//* Выполнила: Трухина Е.Д., группа 2ИСП   *
//* Задание: обработка двумерных массивов  *
//******************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR_10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.DarkMagenta;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            Console.Title = "Практическая работа 10";

            Console.WriteLine("Здравствуй!");

            bool continueProgram = true;

            while (continueProgram)
            {
                const uint row = 3, col = 4;
                int[,] array = new int[row, col];
                Random rnd = new Random();

                bool choise = false;

                while (!choise)
                {
                    Console.Write("Как вы хотите ввести массив?(1/2) \n1)самостоятельно \n2)случайно");
                    Console.Write("\nОтвет: ");
                    string answerB = Console.ReadLine() ?? "";

                    if (answerB == "1")
                    {
                        for (int i = 0; i < row; i++)
                        {
                            for (int j = 0; j < col; j++)
                            {
                                bool isValid = false; // Флаг: ввел ли пользователь число
                                while (!isValid)
                                {
                                    Console.Write("Введите [" + i + "," + j + "] элемент массива: ");
                                    string element = Console.ReadLine();

                                    isValid = Int32.TryParse(element, out array[i, j]);

                                    if (!isValid)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Вы ввели неверный символ! Повторите ввод.");
                                        Console.ForegroundColor = ConsoleColor.White;
                                    }
                                }
                            }
                        }
                        choise = true;
                    }
                    else if (answerB == "2")
                    {
                        int left = 0;
                        int right = 0;

                        // Ввод левой границы
                        bool isLeftValid = false;
                        while (!isLeftValid)
                        {
                            Console.Write("Введите левую границу диапазона, a: ");
                            string inputLeft = Console.ReadLine();
                            try
                            {
                                left = Int32.Parse(inputLeft);
                                isLeftValid = true; // Если ошибки нет, выходим из цикла
                            }
                            catch (FormatException)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Ошибка: Вы ввели не число! Введите цифры.");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            catch (OverflowException)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Ошибка: Число слишком большое или маленькое.");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                        }

                        // Ввод правой границы
                        bool isRightValid = false;
                        while (!isRightValid)
                        {
                            Console.Write("Введите правую границу диапазона, b: ");
                            string inputRight = Console.ReadLine();
                            try
                            {
                                right = Int32.Parse(inputRight);
                                isRightValid = true; // Если ошибки нет, выходим из цикла
                            }
                            catch (FormatException)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Ошибка: Вы ввели не число! Введите цифры.");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            catch (OverflowException)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Ошибка: Число слишком большое или маленькое.");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                        }

                        // Проверка, что левая граница меньше правой
                        while (left > right)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Ошибка: Левая граница не может быть больше правой!");
                            Console.ForegroundColor = ConsoleColor.White;

                            // Заставляем ввести заново
                            isLeftValid = false;
                            while (!isLeftValid)
                            {
                                Console.Write("Введите левую границу диапазона, a: ");
                                try { left = Int32.Parse(Console.ReadLine()); isLeftValid = true; }
                                catch { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Ошибка ввода."); Console.ForegroundColor = ConsoleColor.White; }
                            }
                            isRightValid = false;
                            while (!isRightValid)
                            {
                                Console.Write("Введите правую границу диапазона, b: ");
                                try { right = Int32.Parse(Console.ReadLine()); isRightValid = true; }
                                catch { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Ошибка ввода."); Console.ForegroundColor = ConsoleColor.White; }
                            }
                        }

                        for (int i = 0; i < row; i++)
                        {
                            for (int j = 0; j < col; j++)
                            {
                                array[i, j] = rnd.Next(left, right + 1);
                            }
                        }
                        choise = true;
                    }
                    else
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Ошибка: введите 1 или 2. Попробуйте снова.\n");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }

                Console.WriteLine("Исходный массив:");
                for (int i = 0; i < row; i++)
                {
                    for (int j = 0; j < col; j++)
                    {
                        Console.Write(array[i, j] + "\t");
                    }
                    Console.WriteLine();
                }

                for (int i = 0; i < row; i++)
                {
                    int sum = 0;
                    for (int j = 0; j < col - 1; j++)
                    {
                        sum += array[i, j];
                    }
                    array[i, col - 1] = sum;
                }

                Console.WriteLine("\nРезультирующий массив:");
                for (int i = 0; i < row; i++)
                {
                    for (int j = 0; j < col; j++)
                    {
                        Console.Write(array[i, j] + "\t");
                    }
                    Console.WriteLine();
                }

                bool answerA = false;

                while (!answerA)
                {
                    Console.Write("\nПродолжить выполнение программы? (да/нет): ");
                    string answer = Console.ReadLine();
                    if (answer == null) answer = "";

                    if (answer.ToLower() == "да") // ToLower позволяет писать "Да" или "ДА"
                    {
                        answerA = true;
                        Console.Clear();
                    }
                    else if (answer.ToLower() == "нет")
                    {
                        answerA = true;
                        continueProgram = false;
                        Console.WriteLine("Выход из программы. До свидания!");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Ошибка: введите \"да\" или \"нет\".");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
            }
            Console.ReadKey();
        }
    }
}
