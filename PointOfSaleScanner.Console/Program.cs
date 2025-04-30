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

            foreach (char item in input1)
            {
                terminal.Scan(item.ToString());
            }

            Console.WriteLine($"Total for {input1}: {terminal.CalculateTotal():C}");
            terminal.Reset();

            string input2 = "CCCCCCC";
            foreach (char item in input2)
            {
                terminal.Scan(item.ToString());
            }
            Console.WriteLine($"Total for {input2}: {terminal.CalculateTotal():C}");
            terminal.Reset();

            string input3 = "ABCD";
            foreach (char item in input3)
            {
                terminal.Scan(item.ToString());
            }
            Console.WriteLine($"Total for {input3}: {terminal.CalculateTotal():C}");
            terminal.Reset();
        }
    }
}
