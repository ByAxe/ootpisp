using System;
using System.Collections.Generic;
using ootpisp.utils;

namespace ootpisp
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // -----------------------------------------------------------------
            // ----------------------------LAB 1--------------------------------
            // -----------------------------------------------------------------
            Console.WriteLine($"\nLab1");
            
            var greatestShow = new Performance {
                DateTime = DateTime.Now.AddMonths(1),
                Id = 0,
                Price = new decimal(18.92) ,
                Title = "Greatest Show"
            };
            
            var education = new Education{Title = "Software Engineer"};
            var person = new Person{Age = 25, Gender = Gender.Male, Name = "Alex"};
            
            var visitor = new Visitor{Id = 1, UpcomingPerformances = {greatestShow}, Education = education, Person = person};
            
            Console.WriteLine($"\t{visitor.ToShortString()}");

            // --------------------
            Console.WriteLine($"\nAll possible frequencies");

            var values = EnumUtil.GetValues<Frequency>();
            foreach (var frequency in values)
            {
                Console.WriteLine($"\t-> {frequency}");
            }
            
            // --------------------
            var jimmyFallon = new Performance {
                DateTime = new DateTime(2017, 1, 24),
                Id = 1,
                Price = new decimal(76.22) ,
                Title = "Jimmy Fallon is late!"
            };
            var duSoliel = new Performance {
                DateTime = new DateTime(2018, 3, 28),
                Id = 2,
                Price = new decimal(99.9) ,
                Title = "Du Soleil"
            };
            var duSoliel2 = new Performance {
                DateTime = new DateTime(2018, 7, 11),
                Id = 3,
                Price = new decimal(199.9) ,
                Title = "Du Soleil 2.0"
            };
            
            visitor.AddVisitedPerformance(jimmyFallon);
            visitor.AddVisitedPerformance(duSoliel);
            visitor.AddVisitedPerformance(duSoliel2);

            Console.WriteLine($"\nVisitor after adding history\n\t{visitor.ToShortString()}");


            // -----------------------------------------------------------------
            // ----------------------------LAB 2--------------------------------
            // -----------------------------------------------------------------

        }
    }
}