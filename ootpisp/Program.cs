using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using ootpisp.utils;

namespace ootpisp
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // -----------------------------------------------------------------
            // ----------------------------LAB 1,2--------------------------------
            // -----------------------------------------------------------------
            Console.WriteLine("\nLab1");

            var greatestShow = new Performance
            {
                DateTime = DateTime.Now.AddMonths(1),
                Id = 0,
                Price = new decimal(18.92),
                Title = "Greatest Show"
            };

            var education = new Education {Title = "Software Engineer"};
            var person = new Person {Age = 25, Gender = Gender.Male, Name = "Alex"};

            var visitor = new Visitor
            {
                Age = 25, Gender = Gender.Male, Name = "Alex",
                Id = 1, UpcomingPerformances = {greatestShow}, Education = education
            };

            Console.WriteLine($"\t{visitor.ToShortString()}");

            // --------------------
            Console.WriteLine("\nAll possible frequencies");

            var values = EnumUtil.GetValues<Frequency>();
            foreach (var frequency in values) Console.WriteLine($"\t-> {frequency}");

            // --------------------
            var jimmyFallon = new Performance
            {
                DateTime = new DateTime(2017, 1, 24),
                Id = 1,
                Price = new decimal(76.22),
                Title = "Jimmy Fallon is late!"
            };
            var duSoliel = new Performance
            {
                DateTime = new DateTime(2018, 3, 28),
                Id = 2,
                Price = new decimal(99.9),
                Title = "Du Soleil"
            };
            var duSoliel2 = new Performance
            {
                DateTime = new DateTime(2018, 7, 11),
                Id = 3,
                Price = new decimal(199.9),
                Title = "Du Soleil 2.0"
            };

            visitor.AddVisitedPerformance(jimmyFallon);
            visitor.AddVisitedPerformance(duSoliel);
            visitor.AddVisitedPerformance(duSoliel2);

            Console.WriteLine($"\nVisitor after adding history\n\t{visitor.ToShortString()}");


            // -----------------------------------------------------------------
            // ----------------------------LAB 2--------------------------------
            // -----------------------------------------------------------------
            Console.WriteLine("\n\n\nLab2");

            var visitorCopy = visitor.DeepCopy() as Visitor;
            Debug.Assert(visitorCopy != null, nameof(visitorCopy) + " != null");

            visitorCopy.Id = visitor.Id;
            var equal = visitor.Equals(visitorCopy) ? "Yes" : "No";

            Console.WriteLine($"\nVisitor: \n\t{visitor.ToShortString()}");
            Console.WriteLine($"\nVisitor copy: \n\t{visitorCopy.ToShortString()}");
            Console.WriteLine($"\nAre the equal? {equal}.");


            Console.WriteLine("\nNow we are going to change first Visitor. Watch.");
            visitor.Id = 2;
            visitor.Name = "James";
            visitor.Age = 58;
            visitor.VisitedPerformances = new List<Performance>();

            Console.WriteLine($"\nVisitor: \n\t{visitor.ToShortString()}");
            Console.WriteLine($"\nVisitor copy: \n\t{visitorCopy.ToShortString()}");

            try
            {
                const int thousandYears = 1000;
                Console.WriteLine($"\nLet's try to set age for visitor to... {thousandYears}");
                visitor.Age = thousandYears;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            const decimal borderPrice = 3;
            Console.WriteLine($"\nLet's print all performances with price higher than {borderPrice}...");
            foreach (var performance in visitorCopy.GetNextPerformancePricierThan(borderPrice))
                Console.WriteLine($"\t{performance}");

            // -----------------------------------------------------------------
            // ----------------------------LAB 3--------------------------------
            // -----------------------------------------------------------------
            Console.WriteLine("\n\n\nLab3");

            var visitorCollection = new VisitorCollection();
            visitorCollection.AddDefaults();

            Console.WriteLine("\nLet\'s try to print visitors collection in a short manner...");
            Console.WriteLine(visitorCollection.ToShortString());

            Console.WriteLine("\nLet\'s try to print visitors collection in a long manner...");
            Console.WriteLine(visitorCollection.ToString());
            
            Console.WriteLine("\nLet\'s sort collection via Date");
            visitorCollection.SortCollectionViaDate();
            Console.WriteLine(visitorCollection.ToShortString());

            
            Console.WriteLine("\nLet\'s sort collection via Name");
            visitorCollection.SortCollectionViaName();
            Console.WriteLine(visitorCollection.ToShortString());
            
            Console.WriteLine("\nLet\'s sort collection via Average Mark");
            visitorCollection.SortCollectionViaAverageMark();
            Console.WriteLine(visitorCollection.ToShortString());

            Console.WriteLine($"\nMaximum mark for all the elements of generated collection is...  {visitorCollection.MaxMarkGroup}");

            Console.WriteLine($"\nHere are all the specialists:\n{visitorCollection.VisitorsSpecialistsToString()}");

            const double border = 20;
            var groupsWithAverageMark = visitorCollection.GroupsWithAverageMarkGroup(border);
            var groupsWithAverageMarkString = visitorCollection.GroupsWithAverageMarkToString(groupsWithAverageMark);
            Console.WriteLine($"\nHere all the visitors with average mark higher than 20\n{groupsWithAverageMarkString}");
            
            
            var testCollection = new TestCollection{StartingAmountOfElements = 10000};
            var stopWatch = new Stopwatch();
            
            
            
            Console.WriteLine($"\nLet's search first element");
            stopWatch.Start();
            try
            {
                var result = testCollection.Visitors.First(d => d.Value.Id.Equals(0));
            }
            catch (Exception e)
            {
                // ignored
            }

            stopWatch.Stop();
            Console.WriteLine("\tRunTime of searching first element in Dictionary<Person, Visitor> " 
                              + stopWatch.Elapsed.TotalMilliseconds);
            
            
            
            
            
            stopWatch.Reset();
            
            stopWatch.Start();
            try
            {
                var result1 = testCollection.People.First(d => d.Value.Age.Equals(0));
            }
            catch (Exception e)
            {
                // ignored
            }
            stopWatch.Stop();
            Console.WriteLine("\tRunTime of searching first element in Dictionary<string, Person> " 
                              + stopWatch.Elapsed.TotalMilliseconds);
            
            
            
            
            stopWatch.Reset();
            
            stopWatch.Start();
            try
            {
                var result1 = testCollection.VisitorsList.First(d => d.Age.Equals(0));
            }
            catch (Exception e)
            {
                // ignored
            }
            stopWatch.Stop();
            Console.WriteLine("\tRunTime of searching first element in List<Visitor> " 
                              + stopWatch.Elapsed.TotalMilliseconds);
            
            
            
            stopWatch.Reset();
            
            stopWatch.Start();
            try
            {
                var result1 = testCollection.Strings.First(s => s.Equals("s"));
            }
            catch (Exception e)
            {
                // ignored
            }
            stopWatch.Stop();
            Console.WriteLine("\tRunTime of searching first element in List<string> " 
                              + stopWatch.Elapsed.TotalMilliseconds);
            
            
            
            stopWatch.Reset();
            
            Console.WriteLine($"\nLet's search last element");
            stopWatch.Start();
            try
            {
                var result = testCollection.Visitors.Last(d => d.Value.Id.Equals(0));
            }
            catch (Exception e)
            {
                // ignored
            }

            stopWatch.Stop();
            Console.WriteLine("\tRunTime of searching last element in Dictionary<Person, Visitor> " 
                              + stopWatch.Elapsed.TotalMilliseconds);
            
            
            
            
            
            stopWatch.Reset();
            
            stopWatch.Start();
            try
            {
                var result1 = testCollection.People.Last(d => d.Value.Age.Equals(0));
            }
            catch (Exception e)
            {
                // ignored
            }
            stopWatch.Stop();
            Console.WriteLine("\tRunTime of searching last element in Dictionary<string, Person> " 
                              + stopWatch.Elapsed.TotalMilliseconds);
            
            
            
            
            stopWatch.Reset();
            
            stopWatch.Start();
            try
            {
                var result1 = testCollection.VisitorsList.Last(d => d.Age.Equals(0));
            }
            catch (Exception e)
            {
                // ignored
            }
            stopWatch.Stop();
            Console.WriteLine("\tRunTime of searching last element in List<Visitor> " 
                              + stopWatch.Elapsed.TotalMilliseconds);
            
            
            
            stopWatch.Reset();
            
            stopWatch.Start();
            try
            {
                var result1 = testCollection.Strings.Last(s => s.Equals("s"));
            }
            catch (Exception e)
            {
                // ignored
            }
            stopWatch.Stop();
            Console.WriteLine("\tRunTime of searching last element in List<string> " 
                              + stopWatch.Elapsed.TotalMilliseconds);
            
            

            // -----------------------------------------------------------------
            // ----------------------------LAB 4--------------------------------
            // -----------------------------------------------------------------
            
            
        }
    }
}