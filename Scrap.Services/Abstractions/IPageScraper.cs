using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scrap.Services.Abstractions
{
    public interface IPageScraper
    {
        public IList<Tuple<string, string>> Scrap(IWebDriver webDriver);
    }
}
