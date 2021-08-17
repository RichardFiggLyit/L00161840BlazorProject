using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L00161840BlazorProject.Shared.Helpers
{
    public static class DateHelpers
    {
        public static DateTime GetStartOfDay (this DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day, 0, 0, 0);
        }
        public static DateTime GetEndOfDay(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day, 23, 59, 59);
        }
        public static string ToStandardString(this DateTime date)
        {
            return date.ToString("dd/MM/yyyy");
        }
        public static List<int> GetTaxYears(DateTime startDate, DateTime endDate)
        {
            return Enumerable.Range(startDate.Year, (endDate.Year - startDate.Year) + 1).ToList();
        }
    }
}
