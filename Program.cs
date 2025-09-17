using System;
using static System.Net.Mime.MediaTypeNames;
namespace SimpleLinearRegression
{
    class Program
    {
        static void Main()
        {
            Console.ForegroundColor = ConsoleColor.Green;

            string text = "Калькулятор Простой линейной регрессии";
            Console.SetCursorPosition(((Console.WindowWidth - text.Length) / 2), Console.CursorTop);
            Console.WriteLine(text + "\n");


            Console.Write($"Введите все переменные по X через пробел или запятую: ");

            string[] strX = Console.ReadLine().Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            double[] x = new double[strX.Length];
            for(int i = 0; i < x.Length; i++) 
            {
                x[i] = double.Parse(strX[i]);
            }

            Console.WriteLine($"\nВы ввели {x.Length} значений по X\n");

            Console.Write($"Введите все переменные по Y через пробел или запятую: ");
            string[] strY = Console.ReadLine().Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            double[] y = new double[strY.Length];
            for (int i = 0; i < y.Length; i++)
            {
                y[i] = double.Parse(strY[i]);
            }

            Console.WriteLine($"\nВы ввели {y.Length} значений по Y\n");

            double sumXY_diff = 0;
            double sumX_diff2 = 0;

            double sumX = 0;
            double sumY = 0;

            for (int i = 0; i < y.Length; i++)
            {
                sumX += x[i];
                sumY += y[i];
            }

            double averageX = sumX / y.Length;
            double averageY = sumY / y.Length;

            for (int i = 0; i < y.Length; i++)
            {
                double x_diff = x[i] - averageX;
                double y_diff = y[i] - averageY;

                sumXY_diff += x_diff * y_diff; // (x - x̄)(y - ȳ)
                sumX_diff2 += x_diff * x_diff; // (x - x̄)^2
            }

            double beta = sumXY_diff / sumX_diff2;

            double alpha = averageY - beta * averageX;

            Console.WriteLine("beta: " + beta);
            Console.WriteLine("alfa: " + alpha);


            Console.Write("\nВведите итоговый X, чтобы узнать Y: ");

            double xItog = double.Parse(Console.ReadLine());
            double yItog = beta * xItog + alpha;

            Console.WriteLine($"\nY = {yItog}");
        }
    }
}