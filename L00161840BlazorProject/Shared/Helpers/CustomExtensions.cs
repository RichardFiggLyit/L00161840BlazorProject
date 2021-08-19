using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace L00161840BlazorProject.Shared.Helpers
{
    public static class CustomExtensions
    {
        public static string ToEuro(this double value)
        {
            if (value < 0)
                return "-€" + Math.Abs(value).ToString("#,###,##0.00");
            else
                return "€" + value.ToString("#,###,##0.00");
        }
        public static bool IsAdmin(this ClaimsPrincipal User)
        {
            return User.Claims.Where(x => x.Type == ClaimTypes.Role && x.Value == "Admin").FirstOrDefault() != null;
        }
        public static int EmployeeId(this ClaimsPrincipal User)
        {
            int employeeId = 0;
            string employeeIdString = User.Claims.Where(x => x.Type == "Employee").FirstOrDefault()?.Value;
            int.TryParse(employeeIdString, out employeeId);
            return employeeId;
        }
        public static string ToStandardString(this List<DateTime> dateTimes)
        {
            string output = "";
            List<string> datesString = new List<string>();
            foreach (var date in dateTimes)
                datesString.Add(date.ToShortDateString());
            if (datesString.Count > 0)
                output = String.Join(";", datesString);
            return output;
        }
        public static string ToStandardString(this List<int> values)
        {
            string output = "";
            List<string> datesString = new List<string>();
            foreach (var date in values)
                datesString.Add(date.ToString());
            if (datesString.Count > 0)
                output = String.Join(";", datesString);
            return output;
        }

    }
}
