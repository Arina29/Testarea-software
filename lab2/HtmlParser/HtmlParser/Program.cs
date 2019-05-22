using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using MoreLinq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace HtmlParser
{
    class Program
    {
        static void Main(string[] args)
        {
            var driver = new ChromeDriver();
            var products = new List<Product>();
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            driver.Navigate()
                .GoToUrl("https://md.sportsdirect.com/ladies/ladies-sweatshirts#dcp=1&dppp=100&OrderBy=rank");
            var numberOfPages = Int32.Parse(driver.FindElements(By.ClassName("swipeNumberClick")).LastOrDefault().Text);

            for (int page = 1; page <= numberOfPages; page++)
            {
                driver.Navigate()
                    .GoToUrl("https://md.sportsdirect.com/ladies/ladies-sweatshirts#dcp=" + page +"&dppp=100&OrderBy=rank");
                System.Threading.Thread.Sleep(2100); 

                IList<IWebElement> all = driver.FindElements(By.ClassName("s-productthumbtext"));

                foreach (IWebElement item in all)
                {
                    var price = item.FindElement(By.ClassName("CurrencySizeLarge")).Text;
                    products.Add(new Product() {Name = item.FindElement(By.ClassName("productdescriptionname")).Text,
                                                Price = decimal.Parse(price.Substring(0, price.IndexOf(' ')).Replace(",", ".")) });

                    Console.WriteLine("{0,-60} {1,5:N1}", item.FindElement(By.ClassName("productdescriptionname")).Text, price);
                }

            }

            var cheapestItem = products.MinBy(x => x.Price).FirstOrDefault();
            Console.WriteLine("--------------------------" + cheapestItem.Name +"->" + cheapestItem.Price+"-------------------------------------");
            Console.ReadKey();
            
        }

        public class Product
        {
            public string Name { get; set; }

            public decimal Price { get; set; }
        }
    }
}
