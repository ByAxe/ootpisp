using System;

namespace ootpisp
{
    public class Performance: IDateAndCopy
    {
        public long Id { get; set; }
        public int Version { get; set; } = 1;
        public string Title { get; set; }
        public System.DateTime DateTime { get; set; }
        public decimal Price { get; set; }
        public Frequency Frequency { get; set; } = Frequency.Yearly;

        public override string ToString() => $"Id: {Id}, " +
                                             $"Version: {Version}, " +
                                             $"Title of performance: {Title}, " +
                                             $"Date and Time of performance: {DateTime}, " +
                                             $"Price is: {Price}";

        public object DeepCopy() => new Performance{Date = this.Date, Id = this.Id + 1, Frequency = this.Frequency, 
            DateTime = this.DateTime, Title = this.Title, 
            Version = this.Version, Price = this.Price};

        public DateTime Date { get; set; }
    }
}