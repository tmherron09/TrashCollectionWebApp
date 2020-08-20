using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrashCollection.Models;

namespace TrashCollection
{
    public static class TrashPrices
    {

        public static double MonthlyFee = 8.00;

        public static double GetOneTimePickupCost(Customer customer)
        {
            double price = 10.00;

            if(customer.SpecialtyPickupDay.DayOfWeek == DayOfWeek.Saturday || customer.SpecialtyPickupDay.DayOfWeek == DayOfWeek.Sunday)
            {
                price += 6.00;
            }

            return price;
        }

    }
}
