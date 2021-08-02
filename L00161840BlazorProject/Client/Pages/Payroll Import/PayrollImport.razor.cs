using L00161840BlazorProject.Shared.Entities;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace L00161840BlazorProject.Client.Pages.Payroll_Import
{
    public partial class PayrollImport
    {
        public async Task OnInputFileChange(InputFileChangeEventArgs e)
        {
            csvData = new List<List<string>>();
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
                    csvData.Add(SplitCSV(item.ToString()));
                }
                SetUpMapping();

            }
            
        }

        private List<string> SplitCSV(string input)
        {
            //Excludes commas within quotes  
            Regex csvSplit = new Regex("(?:^|,)(\"(?:[^\"]+|\"\")*\"|[^,]*)", RegexOptions.Compiled);
            List<string> list = new List<string>();
            string curr = null;
            foreach (Match match in csvSplit.Matches(input))
            {
                curr = match.Value;
                if (0 == curr.Length) list.Add("");

                list.Add(curr.TrimStart(',').Replace("\r",""));
            }

            return list;
        }
        private void SetUpMapping()
        {
            headers = csvData[0].ToList();
            PayItems = new List<PayItem>();
            foreach(var header in headers)
            {
                var item = PayItemsDB.Where(x => x.MappedReference.ToLower() == header.ToLower()).FirstOrDefault();
                if (item == null)
                {
                    PayItems.Add(new PayItem()
                    {
                        MappedReference = header
                    });
                }
                else
                {
                    PayItems.Add(item);
                }


            }
        }
    }
}

