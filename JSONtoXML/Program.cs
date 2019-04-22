using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace JSONtoXML
{
    class Program
    {
        /*
         * Simplified version of https://www.ztm.gda.pl/rozklady/rozklad-210_20180328-32-1.html
         * Tested stopId = 1334 - Wagnera 01
         */

        static void Main()
        {
            string uri = "http://87.98.237.99:88/delays?stopId=1334";
            AllBuses allBuses = AllBuses.FromJson(APIrequest.GET(uri));
            allBuses.Arrives.OrderBy(a => a.EstimatedTime);

            XmlDocument doc = new XmlDocument();
            doc.LoadXml("<buses></buses>");

            foreach (var arrive in allBuses.Arrives)
            {
                AddElementToXMLdoc(doc, arrive);

                Console.WriteLine($"{arrive.RouteId}  - {arrive.Headsign} - {CalculateTimeDiffrence(arrive.EstimatedTime)}");
            }
            string xmlFileName = "buses.xml";
            doc.Save(xmlFileName);
            Console.WriteLine($@"Saved to {Directory.GetCurrentDirectory()}\{xmlFileName}");

            Console.ReadKey();
        }

        static string CalculateTimeDiffrence(string arriveTime)
        {
            string[] time = arriveTime.Split(':');
            TimeSpan departureTime = new TimeSpan(int.Parse(time[0]), int.Parse(time[1]), 0);
            TimeSpan now = DateTime.Now.TimeOfDay;
            
            string response = (departureTime - now).TotalMinutes.ToString("0");
            if (response == "1" || response == "0")
                return "TERAZ!";
            else
                return $"za {response} min";
        }

        static void AddElementToXMLdoc(XmlDocument doc, Arrives arrive)
        {
            XmlElement newElem = doc.CreateElement("bus");
            newElem.AppendChild(doc.CreateElement("routeId", arrive.RouteId.ToString()));
            newElem.AppendChild(doc.CreateElement("headsign", arrive.Headsign));
            newElem.AppendChild(doc.CreateElement("departure", CalculateTimeDiffrence(arrive.EstimatedTime)));
            doc.DocumentElement.AppendChild(newElem);
        }
    }
}
