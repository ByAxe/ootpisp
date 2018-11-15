using System;

namespace ootpisp
{
    public class Performance : IDateAndCopy
    {
        public long Id { get; set; }
        public int Version { get; set; } = 1;
        public string Title { get; set; }
        public DateTime DateTime { get; set; }
        public decimal Price { get; set; }
        public Frequency Frequency { get; set; } = Frequency.Yearly;

        public object DeepCopy()
        {
            return new Performance
            {
                Date = Date, Id = Id + 1, Frequency = Frequency,
                DateTime = DateTime, Title = Title,
                Version = Version, Price = Price
            };
        }

        public DateTime Date { get; set; }

        public override string ToString()
        {
            return $"(Id: {Id}, " +
                   $"Version: {Version}, " +
                   $"Title of performance: {Title}, " +
                   $"Date and Time of performance: {DateTime}, " +
                   $"Price is: {Price})";
        }
    }
}