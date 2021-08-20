using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace L00161840BlazorProject.Client.Helpers
{
    public static class NavigationManagerExtensions
    {
        public static string LoginLink(this NavigationManager navigation, string path)
        {
            if (!string.IsNullOrWhiteSpace(path) && path != "/")
            {

                var encodedRedirect = System.Net.WebUtility.UrlEncode(path);
                var query = new Dictionary<string, string> { { "Redirect", encodedRedirect } };
                return QueryHelpers.AddQueryString("Login", query);

            }
            else
                return "Login";
        }
    }
}
