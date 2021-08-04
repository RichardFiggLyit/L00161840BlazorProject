﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace L00161840BlazorProject.Client.Helpers
{
    public static class CustomExtensions
    {
        public static string ToEuro(this double value)
        {
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

    }
}
