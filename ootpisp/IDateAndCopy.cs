using System;

namespace ootpisp
{
    public interface IDateAndCopy
    {
        object DeepCopy();
        DateTime Date { get; set; }
    }
}