using OpenQA.Selenium;
using Scrap.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scrap.Services.PageScrapers
{
    /// <summary>
    /// Regular base collection of links and texts scraper
    /// </summary>
    internal class BasePageScraper
    {

        /// <summary>
        /// Search for each tuple of url + text located in the collection
        /// Here we assume we always read the 'a' tag's url and content
        /// </summary>
        /// <param name="collectionToSearch"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        protected IList<Tuple<string, string>> Scrap(IEnumerable<IWebElement> collectionToSearch)
        {
            var links = new List<Tuple<string, string>>();
            foreach (var element in collectionToSearch)
            {
                var aElements = element.FindElements(By.TagName("a"));
                foreach (var aElement in aElements)
                {
                    string text = aElement.Text;
                    string href = aElement.GetAttribute("href");
                    links.Add(Tuple.Create(text, href));
                }
            }
            return links;
        }
    }
}
