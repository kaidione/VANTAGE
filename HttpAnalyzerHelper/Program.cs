using System;

namespace HttpAnalyzerHelper
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start monitor...");
            HttpAnalyzerAgent ha = new HttpAnalyzerAgent("chifsr.lenovomm.com", true);
            ha.Start();
            Console.ReadKey();
            Console.ReadKey();
            ha.Stop();
            Console.WriteLine("Stop monitor...");
            Console.WriteLine("Print result:");
            foreach (var item in ha.TrafficListCaptured)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("End...");
            Console.ReadKey();
        }
    }
}
