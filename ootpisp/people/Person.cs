using System;
using System.Collections.Generic;

namespace ootpisp
{
    public class Person : IDateAndCopy, IComparable<Person>, IComparer<Person>
    {
        private int _age;

        public int Age
        {
            get => _age;
            set
            {
                if (value > 100 || value <= 0) throw new Exception($"Age cannot be {value} !");
                _age = value;
            }
        }

        public string Name { get; set; } = "";
        public Gender Gender { get; set; } = Gender.Female;
        protected int? AmountOfChildren { get; set; }
        protected bool? HasSecondHalf { get; set; }

        public int CompareTo(Person other)
        {
            return string.Compare(Name, other.Name, StringComparison.Ordinal);
        }

        public int Compare(Person x, Person y)
        {
            if (x != null && y != null) return DateTime.Compare(x.Date, y.Date);

            return 0;
        }

        public object DeepCopy()
        {
            return new Person
            {
                Age = Age, Gender = Gender, Name = Name, Date = Date,
                AmountOfChildren = AmountOfChildren,
                HasSecondHalf = HasSecondHalf
            };
        }

        public DateTime Date { get; set; }

        public override string ToString()
        {
            return $"Age: {Age}, Name: {Name}, Gender: {Gender}";
        }

        protected bool Equals(Person other)
        {
            return Age == other.Age && string.Equals(Name, other.Name) && Gender == other.Gender &&
                   AmountOfChildren == other.AmountOfChildren && HasSecondHalf == other.HasSecondHalf &&
                   Date.Equals(other.Date);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Person) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Age;
                hashCode = (hashCode * 397) ^ (Name != null ? Name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (int) Gender;
                hashCode = (hashCode * 397) ^ AmountOfChildren.GetHashCode();
                hashCode = (hashCode * 397) ^ HasSecondHalf.GetHashCode();
                hashCode = (hashCode * 397) ^ Date.GetHashCode();
                return hashCode;
            }
        }
    }
}