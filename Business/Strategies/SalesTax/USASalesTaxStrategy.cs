using Strategy_Pattern_First_Look.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Strategy_Pattern_First_Look.Business.Strategies.SalesTax
{
    internal class USASalesTaxStrategy : ISalesTaxStrategy
    {
        public decimal GetTaxFor(Order order)
        {
            var destination = order.ShippingDetails.DestinationState.ToLowerInvariant();
            switch (destination)
            {
                case "la": return order.TotalPrice * 0.095m;
                case "ny": return order.TotalPrice * 0.04m;
                case "nyc": return order.TotalPrice * 0.045m;
                default: return 0m;
            }
        }
    }
}