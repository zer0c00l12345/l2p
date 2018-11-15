using System;
using System.Text;
using HtmlAgilityPack;
using System.Net.Http;
//using CsvHelper;
//using Stringbuilder;

namespace ConsoleApp1
{

    class Program
    {
        static void Main(string[] args)
        { GetHtmlAsync(); Console.ReadLine();}

        static void GetHtmlAsync()
        {
            //Declare csv variable 
            var csv = new StringBuilder();

            var alltext = System.IO.File.ReadAllText("C:\\Users\\Desktop\\CSV\\SchoolList.txt");
            var schoolCodelist = alltext.Split(',');

            foreach (var schoolCode in schoolCodelist)
            {

                //Start Parse                 

                var url = "https://app.dca.ca.gov/bppe/view-school.asp?schlcode=" + schoolCode;
                var httpclient = new HttpClient();
                var html = httpclient.GetStringAsync(url);
                var page = html.Result;
                Console.WriteLine(page);

                var p = page.IndexOf("Last Updated");
                page = page.Substring(p);

                //Telephone Number Pull
                p = page.IndexOf("Telephone");
                page = page.Substring(p);
                var p1 = page.IndexOf("<td>");
                var p2 = page.IndexOf("</td>", p1 + 1);
                var telephone = page.Substring(p1, p2 - p1);
                telephone = telephone.Replace("<td>", "");
                telephone = telephone.Replace(" ", "");
                telephone = telephone.Substring(0, 3) + "-" + telephone.Substring(3);

                //Loop to take string from telephon, and display only the  numbers
                var numbersonly = "";
                foreach (var c in telephone)
                {
                    if (c >= '0' && c <= '9') numbersonly += c;

                }
                //Mailing Address Pull
                p = page.IndexOf("Mailing Address");
                page = page.Substring(p);
                p1 = page.IndexOf("<td>");
                p2 = page.IndexOf("</td>", p1 + 1);
                var mailaddr = page.Substring(p1, p2 - p1);
                mailaddr = mailaddr.Replace("<td>", "");
                p = mailaddr.IndexOf("<br");
                var mailstreet = mailaddr.Substring(0, p);
                var mailcity = mailaddr.Substring(p + 8);
                var mailzip = mailcity.Substring(mailcity.Length - 5);                
                //Loop to display full mail address zip code
                if (mailzip.Trim().StartsWith("-"))
                {
                    mailzip = mailcity.Substring(mailcity.Length - 10);
                }

                p = mailaddr.IndexOf("&nbsp");
                var mailstate = mailaddr.Substring(p -2);                
                mailstate = mailstate.Replace("&nbsp", "");
                mailstate = mailstate.Substring(0, mailstate.IndexOf(";"));
                mailstate = mailstate.TrimStart();
                mailcity = mailcity.Substring(0, mailcity.IndexOf(","));
                mailcity = mailcity.TrimStart();               
               
                


                //Physical Address Pull
                p = page.IndexOf("Physical Address");
                page = page.Substring(p);
                p1 = page.IndexOf("<td>");
                p2 = page.IndexOf("</td>", p1 + 1);
                var physaddr = page.Substring(p1, p2 - p1);
                physaddr = physaddr.Replace("<td>", "");
                p = physaddr.IndexOf("<br");
                var physstreet = physaddr.Substring(0, p);
                var physcity = physaddr.Substring(p + 8);
                var physzip = physcity.Substring(physcity.Length - 5);
                //Loop to display full Physical address zip code
                if (physzip.StartsWith("-"))
                {
                    physzip = physcity.Substring(physcity.Length - 10);
                }
                p = physaddr.IndexOf("&nbsp");
                var physstate = physaddr.Substring(p - 2);
                physstate = physstate.Replace("&nbsp", "");
                physstate = physstate.Substring(0, physstate.IndexOf(";"));
                physstate = physstate.TrimStart();
                physcity = physcity.Substring(0, physcity.IndexOf(","));
                physcity = physcity.TrimStart();              

            


                //Phone Print
                Console.WriteLine("Phone: " + numbersonly);

                //Mailing Address Print                
                Console.WriteLine("Mail Street: " + mailstreet);
                Console.WriteLine("Mail City: " + mailcity);
                Console.WriteLine("Mail Zip: " + mailzip);
                Console.WriteLine("Mail State: " + mailstate);

                
                //Physical Address Print                
                Console.WriteLine("Physical Street: " + physstreet);
                Console.WriteLine("Physical City: " + physcity);
                Console.WriteLine("Physical Zip: " + physzip);
                Console.WriteLine("Physical State: " + physstate);
                                           


                //in your loop
                var first = numbersonly.ToString();
                var second = mailstreet.ToString();
                var third = mailcity.ToString();
                var fourth = mailzip.ToString();
                var fifth = physstreet.ToString();
                var sixth = physcity.ToString();
                var seventh = physzip.ToString();
                var eight = schoolCode.ToString();
                var nine = mailstate.ToString();
                var ten = physstate.ToString();
                var newLine = string.Format("\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\",\"{5}\",\"{6}\",\"{7}\",\"{8}\",\"{9}\",{10}", first, second, third, fourth, nine, sixth, seventh, eight, fifth, ten, Environment.NewLine);
                csv.Append(newLine);

            }
            
            //after your loop
            System.IO.File.WriteAllText("C:\\Users\\dlynch\\Desktop\\CSV\\test.csv", csv.ToString());
            
            



        }

    }
}
