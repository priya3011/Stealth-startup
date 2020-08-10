using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;

namespace Stealth_Startup
{
    class ScheduleOrders
    {
        private static readonly string projectFolder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
        private static readonly string fileName = @"orders.json";
        private readonly string orderFilePath = Path.Combine(projectFolder, fileName);
      
        private ScheduleFlights scheduledFlights;


        public ScheduleOrders(ScheduleFlights sc) {
            this.scheduledFlights = sc;
        }

        public void DisplayOrders() {
            JObject JsonResult = JObject.Parse(File.ReadAllText(orderFilePath));
            foreach (KeyValuePair<string, JToken> obj in JsonResult)
            {
                string key = obj.Key;
                string destination = obj.Value["destination"].ToString();

                if (scheduledFlights.flightsListDictionary.ContainsKey(destination))
                {
                    foreach (Dictionary<string, string> item in scheduledFlights.flightsListDictionary[destination])
                    {
                        string flightsInfo = "Order:" + key + ", " + scheduledFlights.GetOutputString(item);
                        Console.WriteLine(flightsInfo);
                    }
                }
                else
                {
                    string flightsInfo = "Order:" + key + ", " + " flightNumber: not scheduled";
                    Console.WriteLine(flightsInfo);
                } 
            }
        }
    }
}
