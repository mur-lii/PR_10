//******************************************
//* Практичсекая работа № 10                *
//* Выполнила: Трухина Е.Д., группа 2ИСП   *
//* Задание: обработка двумерных массивов *
//******************************************
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
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

            try
            {
                bool continueProgram = true;

                while (continueProgram)
                {
                    const uint row = 3, col = 4;
                    int[,] array = new int[row, col];
                    bool error = false;

                        for (int i = 0; i < row; i++)
                        {
                            for (int j = 0; j < col; j++)
                            {
                                error = false;
                                Console.Write("Введите [" + i + "," + j + "] элемент массива: ");
                                string element = Console.ReadLine();
                                error = Int32.TryParse(element, out array[i, j]);
                                if (!error)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Вы ввели неверный символ! Повторите ввод.");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    j--;
                                }
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
                        for (int j = 0; j < col; j++)
                        {
                            if (j != col)
                            {
                                sum = sum + array[i, j];
                            }
                            if (j == col)
                            {
                                array [i, j] = sum;
                            }
                        }
                        Console.WriteLine();
                    }

                    Console.WriteLine("Результирующий массив:");
                    for (int i = 0; i < row; i++)
                    {
                        for (int j = 0; j < col; j++)
                        {
                            Console.Write(array[i, j] + "\t");
                        }
                        Console.WriteLine();
                    }




                    Console.Write("\nПродолжить выполнение программы? (да/нет): ");
                    string answer = Console.ReadLine();

                    if (answer == null)
                    {
                        answer = "";
                    }

                    if (answer.ToLower() != "да")
                    {
                        continueProgram = false;
                        Console.WriteLine("Выход из программы. До свидания!");
                    }
                }
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ошибка: Вы ввели не число! Пожалуйста, введите цифры.");//Если пользователь вводит символы вместо цифр
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch (OverflowException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ошибка: Введенное число слишком большое или слишком маленькое.");//Если введенное число слишком большое или слишком маленькое для типа double
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Произошла непредвиденная ошибка: " + ex.Message);//любая другая ошибка
                Console.ForegroundColor = ConsoleColor.White;
            }

            Console.ReadKey();
        }
    }
}
