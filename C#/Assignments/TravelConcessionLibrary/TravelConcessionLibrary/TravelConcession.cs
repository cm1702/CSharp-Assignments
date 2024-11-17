using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelConcessionLibrary
{
    internal class TravelConcession
    {
        private const decimal TotalFare = 500m; 

        public string CalculateConcession(int age)
        {
            if (age <= 5)
            {
                return "Little Champs - Free Ticket";
            }
            else if (age > 60)
            {
                decimal concession = TotalFare * 0.30m; 
                decimal finalFare = TotalFare - concession;
                return $"Senior Citizen - Fare after concession: {finalFare:C}";
            }
            else
            {
                return $"Ticket Booked - Fare: {TotalFare:C}";
            }
        }
    }
}
