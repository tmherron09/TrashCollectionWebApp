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
        public static double OneTimePickupBaseFee = 10.00;
        public static double OneTimePickupWeekendSurcharge = 6.00;

        public static double GetOneTimePickupCost(Customer customer)
        {
            double price = OneTimePickupBaseFee;

            if(customer.SpecialtyPickupDay.DayOfWeek == DayOfWeek.Saturday || customer.SpecialtyPickupDay.DayOfWeek == DayOfWeek.Sunday)
            {
                price += OneTimePickupWeekendSurcharge;
            }

            return price;
        }

    }
}
