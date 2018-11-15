namespace ootpisp
{
    public class Education
    {
        public string Title { get; set; } = "";
        public EducationType Type { get; set; } = EducationType.Watcher;

        public override string ToString()
        {
            return $"Title: {Title}, Type: {Type}";
        }
    }
}