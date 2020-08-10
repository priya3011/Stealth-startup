using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Stealth_Startup
{
    class ScheduleFlights
    {
        public Dictionary<string, List<Dictionary<string, string>>> flightsListDictionary = new Dictionary<string, List<Dictionary<string, string>>>();
        List<string> flightLists = new List<string>();

        public List<string> GetInput(int i)
        {
            List<string> lines = new List<string>();
            do
            {
                string line = Console.ReadLine();
                if (!string.IsNullOrEmpty(line))
                {
                    if (line != "exit")
                    {
                        string flightNo = this.GetFlightNum(line);
                        string originSym = this.GetOriginSymbol(line);
                        string destinationSym = this.GetDestinationSymbol(line);
                        int day = i;
                        
                        if (!flightsListDictionary.ContainsKey(destinationSym))
                        {
                            flightsListDictionary[destinationSym] = new List<Dictionary<string, string>>();
                        }

                        var flight = this.getFlight(flightNo, day.ToString(), originSym, destinationSym);
                        flightsListDictionary[destinationSym].Add(flight);
                        flightLists.Add(this.GetOutputString(flight));
                    }
                    lines.Add(line);
                }
                else
                {
                    break;
                }
            } while (true);

            return lines;
        }

        public string GetOutputString(Dictionary<string, string> value) {
            return ("Flight:" + value["flightNo"] + "," + " departure:" + value["originSym"] + "," + " arrival:" + value["destinationSym"] + "," + " day:" + value["day"]);
        }

        public Dictionary<string, string> getFlight(string flightNo, string day, string originSym, string destinationSym) {
            return new Dictionary<string, string>
            {
                    { "flightNo", flightNo },
                    { "originSym", originSym },
                    { "destinationSym", destinationSym },
                    { "day", day }

            };
        }

        public void DisplayFlights()
        {
            Console.WriteLine(string.Join(Environment.NewLine, this.flightLists.ToArray()));
        }
          
        public string GetFlightNum(string item)
        {
            Match match = Regex.Match(item, @"(\d)");
            return !string.IsNullOrEmpty(match.Value) ? match.Value : "not Scheduled";
            
        }

        public string GetOriginSymbol(string item)
        {
            Match match = Regex.Match(item, @"(?<=\()(.*?)(?=\))");
            return !string.IsNullOrEmpty(match.Value) ? match.Value : "not Scheduled";
        }

        public string GetDestinationSymbol(string item)
        {
            Match match = Regex.Match(item, @".*\(([^)]*)\)");
            return !string.IsNullOrEmpty(match.Groups[1].Value) ? match.Groups[1].Value : "not Scheduled";
        }

    }
}
