﻿using Strategy_Pattern_First_Look.Business.Models;
using Strategy_Pattern_First_Look.Business.Strategies.SalesTax;
using System;

namespace Strategy_Pattern_First_Look
{
    class Program
    {
        static void Main(string[] args)
        {
            var order = new Order
            {
                ShippingDetails = new ShippingDetails 
                { 
                    OriginCountry = "Sweden",
                    DestinationCountry = "Sweden"
                }
            };

            var destination = order.ShippingDetails.DestinationCountry.ToLowerInvariant();

            order.SalesTaxStrategy = 
                destination == "sweden" ? 
                new SwedenSalesTaxStrategy() : 
                new USASalesTaxStrategy();


            order.LineItems.Add(new Item("CSHARP_SMORGASBORD", "C# Smorgasbord", 100m, ItemType.Literature), 1);
            order.LineItems.Add(new Item("CONSULTING", "Building a website", 100m, ItemType.Service), 1);

            Console.WriteLine(order.GetTax());
        }
    }
}
