using System;
using System.Collections.Generic;
using System.Text;
using TSD.Linq.Task1.Lib.Model;
using System.Threading.Tasks;
using System.Linq;
using NUnit.Framework;
using System.Xml.Linq;


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

        [Test]

        public async Task getTask8()
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

            



            IEnumerable<double> allPrices2019 =
                from price in listePrices19
                select price.Price;
            
            double averagePrices2019 = allPrices2019.Average();
            Console.WriteLine(averagePrices2019);


            IEnumerable<double> allPrices2020 =
                from price in listePrices20
                select price.Price;

            double averagePrices2020 = allPrices2020.Average();
            Console.WriteLine(averagePrices2020);


            IEnumerable<double> allPrices2021 =
                from price in listePrices21
                select price.Price;

            double averagePrices2021 = allPrices2021.Average();
            Console.WriteLine(averagePrices2021);
        }

        [Test]
        public async Task getTask9()
        {
            GoldClient client = new GoldClient();
            DateTime begDate19 = new DateTime(2019, 01, 01);
            DateTime endDate19 = new DateTime(2019, 12, 31);
            DateTime begDate20 = new DateTime(2020, 01, 01);
            DateTime endDate20 = new DateTime(2020, 12, 31);
            DateTime begDate21 = new DateTime(2021, 01, 01);
            DateTime endDate21 = new DateTime(2021, 12, 31);
            DateTime begDate22 = new DateTime(2022, 01, 01);
            DateTime endDate22 = new DateTime(2022, 03, 15);

            List<GoldPrice> listePrices19 = await client.GetGoldPrices(begDate19, endDate19);
            List<GoldPrice> listePrices20 = await client.GetGoldPrices(begDate20, endDate20);
            List<GoldPrice> listePrices21 = await client.GetGoldPrices(begDate21, endDate21);
            List<GoldPrice> listePrices22 = await client.GetGoldPrices(begDate22, endDate22);

            //List<GoldPrice> listePrices19to22 = new List<GoldPrice>();

            listePrices19.AddRange(listePrices19);
            listePrices19.AddRange(listePrices20);
            listePrices19.AddRange(listePrices21);
            listePrices19.AddRange(listePrices22);

            double minPrice19to22 = 
                (from price in listePrices19
                select price.Price).Min();

            IEnumerable<GoldPrice> dateOfMinPrice19to2022 =
                from item in listePrices19
                 where item.Price == minPrice19to22
                 select item;
            List<GoldPrice> listMin = dateOfMinPrice19to2022.ToList();

            GoldPrice dateOfPriceMin = listMin[0];

            IEnumerable<GoldPrice> allPrices = 
                from price in listePrices19
                orderby price.Price descending
                where price.Date.CompareTo(dateOfPriceMin.Date) > 0
                select price;

            List<GoldPrice> listeMax = allPrices.ToList();

            GoldPrice maxDateOfPriceMax = listeMax[0];

            System.Console.WriteLine("best buy gold");
            System.Console.WriteLine();
            System.Console.WriteLine("Date : " + dateOfPriceMin.Date.ToString());
            System.Console.WriteLine("Price : " + dateOfPriceMin.Price.ToString());
            System.Console.WriteLine();
            System.Console.WriteLine();
            System.Console.WriteLine("best sell gold");
            System.Console.WriteLine();
            System.Console.WriteLine("Date : " + maxDateOfPriceMax.Date.ToString());
            System.Console.WriteLine("Price : " + maxDateOfPriceMax.Price.ToString());
            System.Console.WriteLine();
            System.Console.WriteLine();
            System.Console.WriteLine("benefit : " + (maxDateOfPriceMax.Price - dateOfPriceMin.Price).ToString());






        }

        [Test]
        public async Task ToXMLinit()
        {
            GoldClient client = new GoldClient();
            List<GoldPrice> prices = await client.GetGoldPrices(new DateTime(2019, 01, 01), new DateTime(2019, 12, 31));
            List<GoldPrice> prices2020 = await client.GetGoldPrices(new DateTime(2020, 01, 01), new DateTime(2020, 12, 31));
            List<GoldPrice> prices2021 = await client.GetGoldPrices(new DateTime(2021, 01, 01), new DateTime(2021, 12, 31));
            List<GoldPrice> prices2022 = await client.GetGoldPrices(new DateTime(2022, 01, 01), new DateTime(2022, 03, 15));

            prices.AddRange(prices2020);
            prices.AddRange(prices2021);
            prices.AddRange(prices2022);
            await ToXML(prices);
        }
        
        public async Task ToXML(List<GoldPrice> listPrices)
        {

            XDocument docXmlPrices = new XDocument(
                new XComment("here_is_the_price_list"),
                new XElement("list_of_prices_from_2019_to_2022",
                    from item in listPrices
                    select new XElement("Gold",new XElement("Date", item.Date),new XElement("Price", item.Price))
                
                )

                );

            docXmlPrices.Declaration = new XDeclaration("1.0", "utf-8", "true");

            docXmlPrices.Save(@"C:\\Users\\louis\\OneDrive\\Documents\\erasmus\\techofsoft\\listOfPrices.xml");

            

        }
        
        [Test]
        public async Task XMLtoConsInit()
        {
            XDocument doc = XDocument.Load(@"C:\\Users\\louis\\OneDrive\\Documents\\erasmus\\techofsoft\\listOfPrices.xml");
            await XMLtoCons(doc);
        }

        public async Task XMLtoCons(XDocument doc)
        {
            foreach (XElement price in doc.Root.Elements())
            {
                Console.WriteLine("Date : {0}  Price : {1}",
                                    price.Element("Date").Value,
                                    price.Element("Price").Value);
            }
        }

    }
}

