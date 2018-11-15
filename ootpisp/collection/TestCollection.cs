using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using ootpisp.tests;

namespace ootpisp
{
    public class TestCollection : Dictionary<Person, Visitor>
    {
        private static int _idCounter = 99;
        private static readonly Random Random = new Random();
        

        public List<Visitor> VisitorsList { get; set; } = new List<Visitor>();
        public List<string> Strings { get; set; } = new List<string>();
        public Dictionary<Person, Visitor> Visitors { get; set; } = new Dictionary<Person, Visitor>();
        public Dictionary<string, Person> People { get; set; } = new Dictionary<string, Person>();

        public int StartingAmountOfElements
        {
            set
            {
                for (var i = 0; i < value; i++)
                {
                    VisitorsList.Add(GenerateVisitor(i));
                    Strings.Add(GenerateName(GenerateRandomInt(5, 50)));
                    Visitors.Add(GeneratePerson(i), GenerateVisitor(i));
                    People.Add(GenerateName(GenerateRandomInt(5, 50)), GeneratePerson(i));
                }
            }
        }


        public static Visitor GenerateVisitor(int i)
        {
            var upcomingPerformances = new List<Performance>();
            var amountOfUpcomingPerformances = GenerateRandomInt(0, 3);
            for (var j = 0; j < amountOfUpcomingPerformances; j++) upcomingPerformances.Add(GenerateRandomPerformance());
            
            
            var visitedPerformances = new List<Performance>();
            var amountOfVisitedPerformances = GenerateRandomInt(0, 3);
            for (var j = 0; j < amountOfVisitedPerformances; j++) visitedPerformances.Add(GenerateRandomPerformance());
            
            
            var gender = GenerateRandomInt(0, 2) == 0 ? Gender.Male : Gender.Female;
            var age = GenerateRandomInt(10, 100);
            var typeEducation = GenerateRandomInt(0, 2) == 0 ? EducationType.Specialist : EducationType.Watcher;
            var name = GenerateName(GenerateRandomInt(5, 40));
            var id = GetNextId();
            var title = GenerateRandomTitle();
            var date = GenerateRandomDateTime(GenerateRandomInt(1940, 2005), GenerateRandomInt(1, 13),
                GenerateRandomInt(1, 28));
            var marks = GenerateRandomMarks(GenerateRandomInt(0, 50));

            var education = new Education {Title = title, Type = typeEducation};

            var visitor = new Visitor
            {
                Age = age, Gender = gender, Name = name,
                Id = id, UpcomingPerformances = upcomingPerformances, 
                VisitedPerformances = visitedPerformances,
                Education = education, Date = date, Marks = marks
            };

            return visitor;
        }

        private static List<Mark> GenerateRandomMarks(int amountOfMarks)
        {
            var marks = new List<Mark>(amountOfMarks);
            
            for (var i = 0; i < amountOfMarks; i++)
            {
                var evaluatedOn = GenerateRandomInt(0, 101);
                var title = GenerateRandomTitle();
                var visited = GenerateRandomInt(0, 10) == 0;
                
                marks.Add(new Mark{EvaluatedOn = evaluatedOn, Title = title, Visited = visited});
            }

            return marks;
        }

        public static Person GeneratePerson(int i)
        {
            var gender = GenerateRandomInt(0, 2) == 0 ? Gender.Male : Gender.Female;
            var age = GenerateRandomInt(10, 100);
            var name = GenerateName(GenerateRandomInt(5, 40));
            var date = GenerateRandomDateTime(GenerateRandomInt(1940, 2005), GenerateRandomInt(1, 13),
                GenerateRandomInt(1, 28));

            return new Person {Age = age, Date = date, Gender = gender, Name = name};
        }

        public static Performance GenerateRandomPerformance()
        {
            var dateTimeOfPerformance = GenerateRandomDateTime(GenerateRandomInt(2010, 2019), GenerateRandomInt(1, 13),
                GenerateRandomInt(1, 28));
            var frequency = GenerateRandomFrequency();
            var title = GenerateRandomTitle();
            var price = GenerateRandomDecimal(5, 200);
            var id = GetNextId();
            var version = GenerateRandomInt(0, 100);
            var dateUpdate = DateTime.Now;
            

            return new Performance{DateTime = dateTimeOfPerformance, Date = dateUpdate, 
                Frequency = frequency, Id = id, Version = version, 
                Title = title, Price = price};
        }

        private static decimal GenerateRandomDecimal(double lower, double upper)
        {
            var r = Random;
            return new decimal(r.NextDouble() * (upper-lower) + lower);
        } 

        private static Frequency GenerateRandomFrequency()
        {
            var randomInt = GenerateRandomInt(0, 300);
            if (randomInt <= 2) return Frequency.Weekly;
            if (randomInt >= 3 && randomInt <= 30) return Frequency.Monthly;
            else return Frequency.Yearly;
        }

        private static int GenerateRandomInt(int lower, int upper)
        {
            var rnd = Random;
            var age = rnd.Next(lower, upper);

            return age;
        }

        private static DateTime GenerateRandomDateTime(int year, int month, int day)
        {
            return new DateTime(year, month, day);
        }

        private static int GetNextId()
        {
            _idCounter += 1;
            return _idCounter;
        }

        private static string GenerateName(int len)
        {
            var r = Random;
            string[] consonants =
            {
                "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "l", "n", "p", "q", "r", "s", "sh", "zh", "t", "v",
                "w", "x"
            };
            string[] vowels = {"a", "e", "i", "o", "u", "ae", "y"};
            var name = "";
            name += consonants[r.Next(consonants.Length)].ToUpper();
            name += vowels[r.Next(vowels.Length)];
            var b = 2;
            while (b < len)
            {
                name += consonants[r.Next(consonants.Length)];
                b++;
                name += vowels[r.Next(vowels.Length)];
                b++;
            }

            return name;
        }

        private static string GenerateRandomTitle()
        {
            var amountOfWords = GenerateRandomInt(1, 5);
            var resultingTitle = "";

            for (int i = 0; i < amountOfWords; i++)
            {
                var lengthOfWord = GenerateRandomInt(4, 20);
                resultingTitle += GenerateRandomWord(lengthOfWord) + " ";
            }

            return resultingTitle;
        }
        
        
        private static string GenerateRandomWord(int requestedLength)
        {
            var rnd = Random;
            string[] consonants = { "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "n", "p", "q", "r", "s", "t", "v", "w", "x", "y", "z" };
            string[] vowels = { "a", "e", "i", "o", "u" };

            var word = "";

            if (requestedLength == 1)
            {
                word = GetRandomLetter(rnd, vowels);
            }
            else
            {
                for (var i = 0; i < requestedLength; i+=2)
                {
                    word += GetRandomLetter(rnd, consonants) + GetRandomLetter(rnd, vowels);
                }

                word = word.Replace("q", "qu").Substring(0, requestedLength); 
            }

            return word;
        }

        private static string GetRandomLetter(Random rnd, IReadOnlyList<string> letters)
        {
            return letters[rnd.Next(0, letters.Count - 1)];
        }
    }
}