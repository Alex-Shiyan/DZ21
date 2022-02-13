//
// Домашнее задание к занятию 21. Многопоточность. Класс THREAD
//
// Задача 1.Имеется пустой участок земли (двумерный массив) и план сада, который необходимо реализовать.
// Эту задачу выполняют два садовника, которые не хотят встречаться друг с другом.
// Первый садовник начинает работу с верхнего левого угла сада и перемещается слева направо, сделав ряд, он спускается вниз.
// Второй садовник начинает работу с нижнего правого угла сада и перемещается снизу вверх, сделав ряд, он перемещается влево.
// Если садовник видит, что участок сада уже выполнен другим садовником, он идет дальше.
// Садовники должны работать параллельно.
// Создать многопоточное приложение, моделирующее работу садовников.
//


namespace MyApp // Note: actual namespace depends on the project name.
{
    public class Program
    {
        const int n = 10;
        const int m = 20;

        static int[,] array = new int[n, m];

        static void Main(string[] args)
        {
            // план сада, который необходимо реализовать.
            Console.WriteLine("План сада: ");
            Console.WriteLine();
            Random random = new Random();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    array[i, j] = random.Next(1, 99);
                    Console.Write("{0,4} ", array[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            // многопоточное приложение, моделирующее работу садовников.
            ThreadStart threadStart = new ThreadStart(Method1);
            Thread thread = new Thread(threadStart);
            thread.Start();
            Method2();
            Console.WriteLine();


            // План работы садовников
            Console.WriteLine("План работы садовника 100 и садовника 200: ");
            Console.WriteLine();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write("{0,4} ", array[i, j]);
                }
                Console.WriteLine();
            }
            Console.ReadKey();


        }
        // Садовник 1. Обозначается числом 100
        static void Method1()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (array[i, j] < 200)
                    {
                        int time = array[i, j];
                        array[i, j] = 100;
                        Thread.Sleep(time);
                    }
                }
            }

        }
        // Садовник 2. Обозначается числом 200
        static void Method2()
        {
            for (int j = m-1; j >= 0; j--)
            {
                for (int i = n-1; i >= 0; i--)
                {
                    if (array[i, j] < 100)
                    {
                        int time = array[i, j];
                        array[i, j] = 200;
                        Thread.Sleep(time);
                    }
                }
            }

        }
    }   
}

