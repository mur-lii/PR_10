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

            try
            {
                bool continueProgram = true;

                while (continueProgram)
                {
                    const uint row = 3, col = 4;
                    int[,] array = new int[row, col];
                    Random rnd = new Random();
                    bool error = false;

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
                            choise = true; 
                        }
                        else if (answerB == "2")
                        {
                            int left, right;
                            //ввод левой границы
                            while (true)
                            {
                                Console.Write("Введите левую границу диапозона, a: ");
                                try
                                {
                                    left = Int32.Parse(Console.ReadLine());
                                    break;
                                }
                                catch (FormatException ex)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine($"{ex.Message}");
                                    Console.ForegroundColor = ConsoleColor.White;
                                }
                                catch (OverflowException ex)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine($"{ex.Message}");
                                    Console.ForegroundColor = ConsoleColor.White;
                                }
                                catch (Exception ex)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine($"{ex.Message}");
                                    Console.ForegroundColor = ConsoleColor.White;
                                }
                            }

                            //ввод правой границы
                            while (true)
                            {
                                Console.Write("Введите правую границу диапозона, b: ");
                                try
                                {
                                    right = Int32.Parse(Console.ReadLine());
                                    break;
                                }
                                catch (FormatException ex)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine($"{ex.Message}");
                                    Console.ForegroundColor = ConsoleColor.White;
                                }
                                catch (OverflowException ex)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine($"{ex.Message}");
                                    Console.ForegroundColor = ConsoleColor.White;
                                }
                                catch (Exception ex)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine($"{ex.Message}");
                                    Console.ForegroundColor = ConsoleColor.White;
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

                        for (int j = 0; j < col; j++)
                        {
                            if (j == 3)
                            {
                                array[i, j] = sum;
                            }

                            sum += array[i, j];
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

                    bool answerA = false;

                    while (!answerA)
                    {
                        Console.Write("\nПродолжить выполнение программы? (да/нет): ");
                        string answer = Console.ReadLine();

                        if (answer == null)
                        {
                            answer = "";
                        }

                        if (answer == "да")
                        {
                            answerA = true;
                        }
                        else if (answer == "нет")
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
