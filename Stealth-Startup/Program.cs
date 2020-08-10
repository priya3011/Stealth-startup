using System;
using System.Collections.Generic;

namespace Stealth_Startup
{
    class Program
    {
        public ScheduleFlights scheduledFlights = new ScheduleFlights();
        public ScheduleOrders scheduledOrders;

        static void Main(string[] args)
        {
            Program p = new Program();
            p.GetInput();
            p.UserStories();

            Console.ReadKey();
        }

        public void GetInput()
        {
            int i = 1;
            do
            {
                Console.WriteLine("Day" + i + " :");
                List<string> day = scheduledFlights.GetInput(i);

                if (day.Contains("exit"))
                {
                    break;
                }
                i++;
            } while (true);

        }

        public void UserStories()
        {
            Console.WriteLine("Flights Schedule");
            scheduledFlights.DisplayFlights();

            scheduledOrders = new ScheduleOrders(scheduledFlights);
            Console.WriteLine("Orders Schedule");
            scheduledOrders.DisplayOrders();
        }

    }
}
