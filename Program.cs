using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace СhanceNumb
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var sw = new StreamWriter("log_10lab.txt", true, Encoding.UTF8)) //подключение файла для логирования
            {
                int N; //количество бочек
                while (true) //цикл проверки на корректный ввод
                {
                    Console.WriteLine("Введите количество бочонков");
                    if (int.TryParse(Console.ReadLine(), out int a) && (a > 1))
                    {
                        N = a;
                        break;
                    }
                }
                sw.Write($"Количество бочонков = {N}. Номера: ");

                var random = new Random(); //объект типа random
                var numbers = Enumerable.Range(1, N).ToList(); //создание списка с числами от 1 до n
                var numbersCopy = new List<int>(numbers); //дублирование списка с числами от 1 до n

                Console.WriteLine("Номера бочонков:");
                Console.WriteLine("(Для продолжения жмите пробел)");
                for (var i = 0; i < numbers.Count; i++)
                {
                    //for(int j = 0; j< numbersCopy.Count; j++)
                    //{
                    //    Console.Write($"{numbersCopy[j]}, "); //вывод списка, чтобы поглядеть на него
                    //}
                    //Console.WriteLine();
                    var pickIndex = random.Next(numbersCopy.Count); //случайно определяем индекс (число не больше количества элементов в списке). Также каждый раз количество элементов дублированного списка уменьшается
                    var randNumber = numbersCopy[pickIndex];
                    Console.Write($"{randNumber} "); //выводим число со случайным индексом
                    sw.Write($"{randNumber}| ");
                    numbersCopy.RemoveAt(pickIndex); //удаляем использованное число (даже если случайно выпадет повторное число, то в списке будет уже новое значение на этом месте)

                    Console.ReadKey(); //нажать для продолжения
                }
                sw.Write($"\n");     
            }
        }
    }
}
