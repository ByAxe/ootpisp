using System;

namespace ootpisp
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Lab1");
            var performance = new Performance {
                DateTime = DateTime.Now.AddMonths(1),
                Id = 0,
                Price = new decimal(18.92) ,
                Title = "Greatest Show"
            };
            
            var Visitor = new Visitor{};
            
            Console.WriteLine(Visitor.ToShortString());
        }
    }
}