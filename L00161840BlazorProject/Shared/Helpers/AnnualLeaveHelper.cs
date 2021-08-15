using L00161840BlazorProject.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L00161840BlazorProject.Shared.Helpers
{
    public static class AnnualLeaveHelper
    {
        public static List<DateTime> GetWorkingDates(DateTime start, DateTime end)
        {
            if (start > end)
                throw new Exception("Start date cannot be greater than end date.");
            if (end < start)
                throw new Exception("End date cannot be less than the start date.");
            List<DateTime> WorkingDates = new List<DateTime>();
            DateTime checkDate = start;
            while (checkDate < end.AddDays(1))
            {
                if (checkDate.DayOfWeek != DayOfWeek.Saturday && checkDate.DayOfWeek != DayOfWeek.Sunday)
                {
                    WorkingDates.Add(checkDate);
                }
                checkDate = checkDate.AddDays(1);
            }
            
            return WorkingDates;
        }
        public static bool CheckOverlaps(DateTime startDate, DateTime endDate, List<DateRangeDTO> dateRanges)
        {
            
            bool startOverlaps = dateRanges.Where(x => startDate >= x.StartDate && startDate <= x.EndDate).Any();
            bool endOverlaps = dateRanges.Where(x => endDate >= x.StartDate && endDate <= x.EndDate).Any();
            return startOverlaps || endOverlaps;
        }
    }
}
