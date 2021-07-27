using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace L00161840BlazorProject.Client.Shared
{
    public partial class ImportFile
    {
        public async Task OnInputFileChange(InputFileChangeEventArgs e)
        {
            List<string[]> csv = new List<string[]>();
            var singleFile = e.File;

            Regex regex = new Regex(".+\\.csv", RegexOptions.Compiled);
            if (!regex.IsMatch(singleFile.Name))
            {
                //show error invalidad format file  
            }
            else
            {
                var stream = singleFile.OpenReadStream();
                MemoryStream ms = new MemoryStream();
                await stream.CopyToAsync(ms);
                stream.Close();
                var outputFileString = System.Text.Encoding.UTF8.GetString(ms.ToArray());

                foreach (var item in outputFileString.Split(Environment.NewLine))
                {
                    csv.Add(SplitCSV(item.ToString()));
                }

            }

        }

        private string[] SplitCSV(string input)
        {
            //Excludes commas within quotes  
            Regex csvSplit = new Regex("(?:^|,)(\"(?:[^\"]+|\"\")*\"|[^,]*)", RegexOptions.Compiled);
            List<string> list = new List<string>();
            string curr = null;
            foreach (Match match in csvSplit.Matches(input))
            {
                curr = match.Value;
                if (0 == curr.Length) list.Add("");

                list.Add(curr.TrimStart(','));
            }

            return list.ToArray();
        }
    }
}
