using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyClassLib.Model
{
    public class DateRange : ValueObject
    {
        public DateTime Start { get; private set; }
        public DateTime End { get; private set; }

        public DateRange() { }

        public DateRange(DateTime start, DateTime end)
        {
            if (start < end)
            {
                Start = start;
                End = end;
            }
            else
            {
                throw new Exception("DateRange is not valid");
            }
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Start;
            yield return End;
        }
    }
}
