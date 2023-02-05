using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandyMaker
{
    public class Maker
    {
        TemperatureChecker tcheck = new TemperatureChecker();
        int t = 165;// temp in C
        
        public int CheckNougatTemperature()
        {
            Console.WriteLine("Nougat temperature: " + t + " C");
            return t;
        }
        public void CheckAirSystem()
        {
                Console.WriteLine("Checking Air System . . .");
                if (tcheck.air == true)
                {
                    Console.WriteLine("Air Present in System");
                }
        }
    }
}
