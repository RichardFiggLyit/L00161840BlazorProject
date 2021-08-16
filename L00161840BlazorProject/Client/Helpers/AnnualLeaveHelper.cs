using L00161840BlazorProject.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using L00161840BlazorProject.Client.Repository;
using L00161840BlazorProject.Shared.Helpers;
using System.Net;
using L00161840BlazorProject.Shared.Entities;

namespace L00161840BlazorProject.Client.Helpers
{
    public static class AnnualLeaveHelper
    {


        public static async Task<AnnualLeaveEntitlement> GetandCreateEntitlementYear(int employeeId, int taxYear, IAnnualLeaveEntitlementRepository repository)
        {

            var entitlement = await repository.GetAnnualLeaveEntitlementByEmployeedId(employeeId, taxYear);
            if (entitlement == null)
            {
                entitlement = await repository.CreateAnnualLeaveEntitlement(new AnnualLeaveEntitlement(employeeId, taxYear));
            }

            return entitlement;
        }
        public static List<RequestYear> GetLeaveDays(DateTime startDate, DateTime endDate)
        {
            List<RequestYear> requestYears = new List<RequestYear>();
            var workingDates = GetWorkingDates(startDate, endDate);
            requestYears = workingDates.GroupBy(x => x.Year).Select(x => new RequestYear { TaxYear = x.Key, Requested = x.Count() }).ToList();
            return requestYears;
        }

        public static List<DateTime> GetWorkingDates(DateTime start, DateTime end)
        {
            end = end.GetStartOfDay();
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
