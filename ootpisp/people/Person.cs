using System;
using System.Collections.Generic;

namespace ootpisp
{
    public class Person : IDateAndCopy
    {
        private int _age = 0;

        public int Age
        {
            get => _age;
            set
            {
                if (value > 100 || value <= 0)
                {
                    throw new Exception($"Age cannot be {value} !");
                }
                _age = value;
            }
        }

        public string Name { get; set; } = "";
        public Gender Gender { get; set; } = Gender.Female;
        protected int? AmountOfChildren { get; set; } = null;
        protected bool? HasSecondHalf { get; set; } = null;

        public override string ToString() => $"Age: {Age}, Name: {Name}, Gender: {Gender}";

        protected bool Equals(Person other)
        {
            return Age == other.Age && string.Equals(Name, other.Name) && Gender == other.Gender && AmountOfChildren == other.AmountOfChildren && HasSecondHalf == other.HasSecondHalf && Date.Equals(other.Date);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
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

        public object DeepCopy()
        {
            return new Person
            {
                Age = this.Age, Gender = this.Gender, Name = this.Name, Date = this.Date,
                AmountOfChildren = this.AmountOfChildren,
                HasSecondHalf = this.HasSecondHalf
            };
        }

        public DateTime Date { get; set; }
    }
}