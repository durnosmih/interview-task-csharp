using Microsoft.Extensions.DependencyInjection;
using PointOfSaleScanner.Core;
using PointOfSaleScanner.DependencyInjection;

namespace PointOfSaleScanner.Console
{
    using Console = System.Console;

    internal class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddPointOfSaleScanner()
                .BuildServiceProvider();

            var terminal = serviceProvider.GetRequiredService<PointOfSaleTerminal>();

            terminal.SetPricing("A", 1.25m, 3.00m, 3);
            terminal.SetPricing("B", 4.25m);
            terminal.SetPricing("C", 1.00m, 5.00m, 6);
            terminal.SetPricing("D", 0.75m);

            string input1 = "AAAABCDAAA";
            RunTest(input1, terminal);

            string input2 = "CCCCCCC";
            RunTest(input2, terminal);

            string input3 = "ABCD";
            RunTest(input3, terminal);
        }

        static void RunTest(string input, PointOfSaleTerminal terminal)
        {
            foreach (char item in input)
            {
                terminal.Scan(item.ToString());
            }
            Console.WriteLine($"Total for {input}: {terminal.CalculateTotal():C}");
            terminal.Reset();
        }
    }
}
