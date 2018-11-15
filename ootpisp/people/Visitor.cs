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
        public long Id { get; set; } = 0;
        public Education Education { get; set; } = new Education();
        public List<Performance> UpcomingPerformances { set; get; } = new List<Performance>();
        public List<Performance> VisitedPerformances { set; get; } = new List<Performance>();
        public List<Mark> Marks { get; set; } = new List<Mark>();
        
        public decimal AveragePrice {
            get
            {
                var sum = decimal.Zero;
                var amountOfElements = VisitedPerformances.Count;

                if (amountOfElements == 0) return 0;
                
                foreach (var performance in VisitedPerformances)
                {
                    sum += performance.Price;
                }

                var averagePrice = sum / amountOfElements;
                
                return averagePrice;
            }
        }
        
        public bool SecondTime => AveragePrice != decimal.Zero;

        public void AddVisitedPerformance(Performance performance)
        {
            VisitedPerformances.Add(performance);
        }

        public void AddUpcomingPerformance(Performance performance)
        {
            UpcomingPerformances.Add(performance);
        }

        public virtual string ToShortString() => this.ToString() + $", Id: {Id}, Education: {Education}, AveragePrice: {AveragePrice}";

        public new object DeepCopy() => new Visitor
        {
            Date = this.Date, Education = this.Education,
            Id = this.Id + 1, Marks = this.Marks, UpcomingPerformances = this.UpcomingPerformances,
            VisitedPerformances = this.VisitedPerformances, Age = this.Age, Gender = this.Gender,
            Name = this.Name, AmountOfChildren = this.AmountOfChildren, HasSecondHalf = this.HasSecondHalf
        };

        public new DateTime Date { get; set; }

        public IEnumerable GetNextUpcomingPerformance()
        {
            foreach (var upcomingPerformance in UpcomingPerformances)
            {
                yield return upcomingPerformance;
            }
        }
        
        public IEnumerable GetNextPerformance()
        {
            IList<Performance> performances = new List<Performance>(UpcomingPerformances);
            
            foreach (var performance in performances.Concat(VisitedPerformances))
            {
                yield return performance;
            }
        }

        public IEnumerable GetNextPerformancePricierThan(decimal price)
        {
            IList<Performance> performances = new List<Performance>(UpcomingPerformances);
            
            foreach (var performance in performances.Concat(VisitedPerformances))
            {
                if (performance.Price >= price)
                {
                    yield return performance;
                }
                    
            }
        }
        
        
    }
}