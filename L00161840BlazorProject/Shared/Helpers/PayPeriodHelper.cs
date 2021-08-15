using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using L00161840BlazorProject.Shared.Entities;

namespace L00161840BlazorProject.Shared.Helpers
{
    public static class PayPeriodHelper
    {
        public static DateTime SuggestedMaxPayDate(int taxYear, int taxPeriod, Period period)
        {
            DateTime suggested = new DateTime(taxYear - 1, 12, 31);
            int dayAdjustment = 0;
            int maxPeriods;
            switch (period)
            {
                default:
                case Period.Monthly:
                    suggested = new DateTime(taxYear, taxPeriod, DateTime.DaysInMonth(taxYear, taxPeriod));
                    maxPeriods = 12;
                    break;
                case Period.Fortnightly:
                    dayAdjustment = 14;
                    maxPeriods = 27;
                    break;
                case Period.Weekly:
                    dayAdjustment = 7;
                    maxPeriods = 53;
                    break;
                case Period.FourWeekly:
                    dayAdjustment = 28;
                    maxPeriods = 14;
                    break;
            }
            if (taxPeriod > maxPeriods)
                throw new ArgumentOutOfRangeException($"Tax Period {taxPeriod} is greater than maximum number of tax periods in a year!");
            if (period != Period.Monthly)
            {
                if (taxPeriod == maxPeriods)
                {
                    //Week 53, Fortnight 17 and 4 weekly 14 are all on last day of the year
                    suggested = new DateTime(taxYear, 12, 31);
                }
                else
                {
                    int days = dayAdjustment * taxPeriod;
                    suggested = suggested.AddDays(days);
                }
            }
            return suggested;
            

        }
    }
}
