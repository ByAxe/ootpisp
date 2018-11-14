namespace ootpisp
{
    public class Performance
    {
        public long Id { get; set; }
        public int Version { get; set; } = 1;
        public string Title { get; set; }
        public System.DateTime DateTime { get; set; }
        public decimal Price { get; set; }
        public Frequency Frequency { get; set; } = Frequency.Yearly;

        public override string ToString()
        {
            return $"Id: {Id}, " +
                   $"Version: {Version}, " +
                   $"Title of performance: {Title}, " +
                   $"Date and Time of performance: {DateTime}, " +
                   $"Price is: {Price}";
        }
    }
}