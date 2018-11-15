using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ootpisp.tests;

namespace ootpisp
{
    public class Visitor : Person, IDateAndCopy
    {
        private readonly decimal _averagePrice;
        public long Id { get; set; }
        public Education Education { get; set; } = new Education();
        public List<Performance> UpcomingPerformances { set; get; } = new List<Performance>();
        public List<Performance> VisitedPerformances { set; get; } = new List<Performance>();
        public List<Mark> Marks { get; set; } = new List<Mark>();

        public decimal AveragePrice
        {
            get
            {
                var sum = decimal.Zero;
                var amountOfElements = VisitedPerformances.Count;

                if (amountOfElements == 0) return 0;

                foreach (var performance in VisitedPerformances) sum += performance.Price;

                var averagePrice = sum / amountOfElements;

                return averagePrice;
            }
        }

        public bool SecondTime => AveragePrice != decimal.Zero;

        public new object DeepCopy()
        {
            return new Visitor
            {
                Date = Date, Education = Education,
                Id = Id + 1, Marks = Marks, UpcomingPerformances = UpcomingPerformances,
                VisitedPerformances = VisitedPerformances, Age = Age, Gender = Gender,
                Name = Name, AmountOfChildren = AmountOfChildren, HasSecondHalf = HasSecondHalf
            };
        }

        public new DateTime Date { get; set; }

        public void AddVisitedPerformance(Performance performance)
        {
            VisitedPerformances.Add(performance);
        }

        public void AddUpcomingPerformance(Performance performance)
        {
            UpcomingPerformances.Add(performance);
        }

        public override string ToString()
        {
            return ToShortString() + ", " + $"Visited Performances: [{string.Join("; ", VisitedPerformances)}], " +
                   $"Upcoming Performances: [{string.Join("; ", UpcomingPerformances)}], " +
                   $"Marks: [{string.Join("; ", Marks)}]";
        }

        public virtual string ToShortString()
        {
            return $"Id: {Id}, Name: {Name}, Date: {Date}, Education: ({Education}), AveragePrice: {AveragePrice}";
        }

        public IEnumerable GetNextUpcomingPerformance()
        {
            foreach (var upcomingPerformance in UpcomingPerformances) yield return upcomingPerformance;
        }

        public IEnumerable GetNextPerformance()
        {
            IList<Performance> performances = new List<Performance>(UpcomingPerformances);

            foreach (var performance in performances.Concat(VisitedPerformances)) yield return performance;
        }

        public IEnumerable GetNextPerformancePricierThan(decimal price)
        {
            IList<Performance> performances = new List<Performance>(UpcomingPerformances);

            foreach (var performance in performances.Concat(VisitedPerformances))
                if (performance.Price >= price)
                    yield return performance;
        }
    }
}