using System.Collections.Generic;

namespace ootpisp
{
    public class VisitorComparer : IComparer<Visitor>
    {
        public int Compare(Visitor x, Visitor y)
        {
            if (x != null && y != null)
                return decimal.Compare(x.AveragePrice, y.AveragePrice);
            return 0;
        }
    }
}