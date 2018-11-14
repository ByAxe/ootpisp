using System;
using System.Collections.Generic;

namespace ootpisp
{
    public class Visitor
    {
        private readonly decimal _averagePrice;
        public long Id { get; set; } = 0;
        public Person Person { get; set; } = new Person();
        public Education Education { get; set; } = new Education();
        public List<Performance> UpcomingPerformances { set; get; } = new List<Performance>();
        public List<Performance> VisitedPerformances { set; get; } = new List<Performance>();
        
        public decimal AveragePrice {
            get
            {
                var sum = decimal.Zero;
                var amountOfElements = VisitedPerformances.Count;
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

        public virtual string ToShortString()
        {
            return $"Id: {Id}, Person: {Person}, Education: {Education}, AveragePrice: {AveragePrice}";
        }

    }
}