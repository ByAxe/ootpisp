namespace ootpisp
{
    public class Person
    {
        public int Age { get; set; } = 0;
        public string Name { get; set; } = "";
        public Gender Gender { get; set; } = Gender.Female;

        public override string ToString()
        {
            return $"Age: {Age}, Name: {Name}, Gender: {Gender}";
        }
    }
}