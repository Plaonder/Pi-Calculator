using System;
using System.Threading.Tasks;

namespace PICalculator {
    
    class Program {
        
        static void Main(string[] args) {
            double  iterations = 0;
            bool    PauseAfterRun = true;

            if (args.Length > 0) {
                iterations = Convert.ToDouble(args[0]);
                PauseAfterRun = false;
            } else {
                Console.WriteLine("How many iterations do you want to do?");
                iterations = Convert.ToDouble(Console.ReadLine());
            }

            MultiThreadedFor(iterations);

            if (PauseAfterRun) {
                Console.ReadKey();
            }
        }

        static void MultiThreadedFor(double rectangleNumber) {
            long runs = 0;
            //double rectangleNumber = Convert.ToDouble(Console.ReadLine());

            double width = 2 / rectangleNumber;
            double height = 0;
            double midPoint = 0;
            double pi = 0;
            Parallel.For(0, Convert.ToInt64(rectangleNumber), i => {
                midPoint = (i * width) + (width / 2);
                height = Math.Sqrt(4 - (midPoint * midPoint));
                pi += height * width;
                // Console.WriteLine($"pi is {pi}, height is {height}, midPoint is {midPoint}");
                runs += 1;
                //if (runs % 10000 == 0) {
                    Console.Write($"\rRunning iteration {runs} out of {rectangleNumber}");
                //}
            });
            Console.WriteLine($"\nCalculated Pi is {pi}");
            Console.WriteLine($"      Real Pi is {Math.PI}");
            double error = (Math.Abs(pi - Math.PI) / Math.Abs(Math.PI)) * 100;
            Console.WriteLine($"The error of pi was {error}");
        }
        
        static void SingleThreadedFor() {
            double rectangleNumber = Convert.ToDouble(Console.ReadLine());

            double width = 2 / rectangleNumber;
            double height = 0;
            double midPoint = 0;
            double pi = 0;
            for (int i = 0; i <= rectangleNumber - 1; i++)
            {
                midPoint = (i * width) + (width / 2);
                height = Math.Sqrt(4 - (midPoint * midPoint));
                pi += height * width;
                // Console.WriteLine($"pi is {pi}, height is {height}, midPoint is {midPoint}");
                Console.Write($"\rRunning iteration {i} out of {rectangleNumber}");
            }
        }
    }

}
