using System;
using System.Collections.Generic;
using System.Linq;

namespace ootpisp
{
    public class VisitorCollection
    {
        public List<Visitor> Visitors { get; set; } = new List<Visitor>();
        const int VisitorsByDefault = 10;

        public decimal MaxAveragePrice
        {
            get { return Visitors.Max(v => v.AveragePrice); }
        }

        public IEnumerable<Visitor> VisitorsSpecialists
        {
            get { return Visitors.Where(v => v.Education.Type == EducationType.Specialist); }
        }

        public string VisitorsSpecialistsToString() => VisitorsSpecialists.Aggregate("", (current, visitor) => current + (visitor.ToShortString() + "\n"));

        public List<List<Visitor>> GroupsWithAverageMarkGroup(double value)
        {
            return Visitors.Where(v => (v.Marks.Average(m => m.EvaluatedOn) >= value))
                .GroupBy(v => v.Marks.Average(m => m.EvaluatedOn))
                .Select(grp => grp.ToList())
                .ToList();
        }

        public string GroupsWithAverageMarkToString(List<List<Visitor>> groups)
        {
            if (groups == null) throw new ArgumentNullException(nameof(groups));
            var result = "";
            
            for (var index = 0; index < groups.Count; index++)
            {
                var group = groups[index];
                result += $"Group {index}\n";
                
                foreach (var visitor in group)
                {
                    result += "\t" + visitor.ToShortString() + "\n";
                }
            }


            return result;
        }


        public double MaxMarkGroup
        {
            get
            {
                return Visitors.Max(v => v.Marks.Average(m => m.EvaluatedOn));
            }
        }

        public void AddDefaults()
        {
            for (var i = 0; i < VisitorsByDefault; i++) Visitors.Add(TestCollection.GenerateVisitor(0));
        }

        public override string ToString()
        {
            var result = "";
            foreach (var visitor in Visitors) result += visitor + "\n";
            return result;
        }

        public string ToShortString()
        {
            var result = "";
            foreach (var visitor in Visitors) result += visitor.ToShortString() + "\n";
            return result;
        }

        public void SortCollectionViaName()
        {
            Visitors = Visitors.OrderBy(v => v.Name).ToList();
        }

        public void SortCollectionViaAverageMark()
        {
            Visitors = Visitors.OrderBy(v => v.AverageMark).ToList();
        }

        public void SortCollectionViaDate()
        {
            Visitors = Visitors.OrderBy(v => v.Date).ToList();
        }
    }
}