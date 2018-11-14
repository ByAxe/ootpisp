namespace ootpisp
{
    public class Education
    {
        public string Title { get; set; } = "";

        public override string ToString()
        {
            return $"Title: {Title}";
        }
    }
}