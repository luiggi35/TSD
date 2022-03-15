﻿using System;
using System.Collections.Generic;
using System.Text;
using TSD.Linq.Task1.Lib.Model;
using System.Threading.Tasks;
using System.Linq;
using NUnit.Framework;


namespace TSD.Linq.Task1.Lib
{
    public class Main
    {
        public static void main(string[] args)
        {



        }

        [Test]
        public async Task getPrices()
        {
            GoldClient client = new GoldClient();
            DateTime begAnnee = new DateTime(2021, 01, 01);
            DateTime endAnnee = new DateTime(2021, 12, 31);

            List<GoldPrice> listePrices2021 = await client.GetGoldPrices(begAnnee, endAnnee);


            IEnumerable<GoldPrice> allPrices =
                from price in listePrices2021
                orderby price.Price ascending
                select price;

            var listAllPrices = allPrices.ToList();

            List<Double> low3 = new List<Double>();
            List<Double> high3 = new List<Double>();

            for (int i = 0; i < 3; i++)
            {
                low3.Add(listAllPrices[i].Price);
                Console.WriteLine("price : " + listAllPrices[i].Price.ToString() + "  date : " + listAllPrices[i].Date.ToString());
            }

            for (int i = listAllPrices.Count - 3; i < listAllPrices.Count; i++)
            {
                high3.Add(listAllPrices[i].Price);
                Console.WriteLine("price : " + listAllPrices[i].Price.ToString() + "  date : " + listAllPrices[i].Date.ToString());
            }

        }

        [Test]
        public async Task getTask3()
        {
            GoldClient client = new GoldClient();
            DateTime begDate = new DateTime(2020, 01, 01);
            DateTime endDate = new DateTime(2020, 01, 31);

            List<GoldPrice> listePrices2020Jan = await client.GetGoldPrices(begDate, endDate);



            IEnumerable<GoldPrice> allPrices =
                from price in listePrices2020Jan
                where price.Price >= 1.05 * listePrices2020Jan[0].Price
                select price;

            var listAllPrices = allPrices.ToList();
            for (int i = 0; i < listAllPrices.Count; i++)
            {
                Console.WriteLine(listAllPrices[i].Date.ToString());
            }

        }

        [Test]
        public async Task getTask4()
        {
            GoldClient client = new GoldClient();
            DateTime begDate19 = new DateTime(2019, 01, 01);
            DateTime endDate19 = new DateTime(2019, 12, 31);
            DateTime begDate20 = new DateTime(2020, 01, 01);
            DateTime endDate20 = new DateTime(2020, 12, 31);
            DateTime begDate21 = new DateTime(2021, 01, 01);
            DateTime endDate21 = new DateTime(2021, 12, 31);

            List<GoldPrice> listePrices19 = await client.GetGoldPrices(begDate19, endDate19);
            List<GoldPrice> listePrices20 = await client.GetGoldPrices(begDate20, endDate20);
            List<GoldPrice> listePrices21 = await client.GetGoldPrices(begDate21, endDate21);

            listePrices19.AddRange(listePrices20);
            listePrices19.AddRange(listePrices21);



            IEnumerable<GoldPrice> allPrices =
                from price in listePrices19
                orderby price.Price descending
                select price;

            var l = allPrices.ToList();
            List<DateTime> days = new List<DateTime>();

            days.Add(l[10].Date);
            days.Add(l[11].Date);
            days.Add(l[12].Date);

            Console.WriteLine(l[10].Date.ToString());
            Console.WriteLine(l[11].Date.ToString());
            Console.WriteLine(l[12].Date.ToString());



        }
    }
}

