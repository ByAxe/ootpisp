namespace ootpisp.tests
{
    public class Mark
    {
        public string Title { get; set; }
        public double EvaluatedOn { get; set; }
        public bool Visited { get; set; }

        public override string ToString()
        {
            return $"Title: {Title}, Evaluated on: {EvaluatedOn}, Visited: {Visited}";
        }
    }
}