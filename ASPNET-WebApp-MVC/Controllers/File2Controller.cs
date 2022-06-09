using ASPNET_WebApp_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

using System.Xml.Serialization;
using System.Collections.Generic;

namespace ASPNET_WebApp_MVC.Controllers
{
    public class File2Controller : Controller
    {
        public IActionResult Index()
        {
            var _dataSet = BuildDataSet();
            ViewData["InputData"] = _dataSet;

            return View(_dataSet);
        }

        public IActionResult Results()
        {
            var _dataSet = BuildDataSet();
            var _translated = TranslateDataSet(_dataSet);

            ViewData["Results"] = _translated;

            return View(_translated);
        }

        public List<InputFile2> BuildDataSet()
        {
            /* fake data #2 */
            var _fakeDataSet = new List<InputFile2>
            {
                new InputFile2() { CustodianCode="Efg", Name="Sunita Ram", Type=1, Currency="U"},
                new InputFile2() { CustodianCode="Hij", Name="Yuri Fedorov", Type=2, Currency="C"},
                new InputFile2() { CustodianCode="Klm", Name="Jack Cohen", Type=3, Currency="U"},
                new InputFile2() { CustodianCode="Nop", Name="Gloria Bee", Type=4, Currency="C"},
                new InputFile2() { CustodianCode="Qrs", Name="Fredrik Johansson", Type=1, Currency="U"}
            };

            return _fakeDataSet;
        }

        public List<TargetFile> TranslateDataSet(List<InputFile2> InputDataSet)
        {
            /* translated data (empty output file) */
            var _translatedDataSet = new List<TargetFile>();

            /* loop through input data and build output */
            foreach (InputFile2 item in InputDataSet)
            {
                TargetFile _outfile = new TargetFile();

                /* make decisions what to do for translated data */

                _outfile.Id = 0; // unspecified
                _outfile.AccountCode = item.CustodianCode; /* only the name is changed (not the underlying data) */

                _outfile.Name = item.Name; /* nothing is changed */

                /* account type */
                if (item.Type == 1)
                {
                    _outfile.Type = TargetFile.AccountType.Trading;
                }
                else if (item.Type == 2)
                {
                    _outfile.Type = TargetFile.AccountType.RRSP;
                }
                else if (item.Type == 3)
                {
                    _outfile.Type = TargetFile.AccountType.RESP;
                }
                else if (item.Type == 4)
                {
                    _outfile.Type = TargetFile.AccountType.Fund;
                }
                else
                {
                    _outfile.Type = TargetFile.AccountType.Trading; // maybe handle this with a "None" (enum) but its not in the spec, default to Trading - i would normally clarify this ahead of time (instead of making an assumption here)
                }

                /* convert to actual date */
                _outfile.OpenedDate = Convert.ToDateTime(null); // unspecified (NULL)

                /* currency */
                if (item.Currency == "U") // values are "U" = USD or "C" = CAD
                {
                    _outfile.Currency = TargetFile.CurrencyCode.USD;
                }
                else
                {
                    _outfile.Currency = TargetFile.CurrencyCode.CAD; // maybe handle this with a "None" (enum) if unspecified, like above just assuming CAD as default
                }

                // add the data row
                _translatedDataSet.Add(_outfile);

            }

            return _translatedDataSet;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}