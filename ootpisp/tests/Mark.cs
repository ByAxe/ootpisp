namespace ootpisp.tests
{
    public class Mark
    {
        public string Title { get; set; }
        public int EvaluatedOn { get; set; }
        public bool Visited { get; set; }

        public override string ToString() => $"Title: {Title}, Evaluated on: {EvaluatedOn}, Visited: {Visited}";
    }
}