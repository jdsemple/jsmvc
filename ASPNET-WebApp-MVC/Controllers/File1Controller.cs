using ASPNET_WebApp_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

using System.Xml.Serialization;
using System.Collections.Generic;

namespace ASPNET_WebApp_MVC.Controllers
{
    public class File1Controller : Controller
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

        public List<InputFile1> BuildDataSet()
        {
            /* fake data */
            var _fakeDataSet = new List<InputFile1>
            {
                new InputFile1() { Identifier="123|Abc", Name="Jonathan Lee", Type=1, Opened="01-01-2018", Currency="CD"},
                new InputFile1() { Identifier="234|Bcd", Name="Chris Blue", Type=2, Opened="02-03-2019", Currency="CD"},
                new InputFile1() { Identifier="345|Cde", Name="Hiro Yamaguchi", Type=3, Opened="03-04-2020", Currency="US"},
                new InputFile1() { Identifier="456|Def", Name="Sara Muhammad", Type=4, Opened="04-05-2021", Currency="CD"}
            };

            return _fakeDataSet;
        }

        public List<TargetFile> TranslateDataSet(List<InputFile1> InputDataSet)
        {
            /* translated data (empty output file) */
            var _translatedDataSet = new List<TargetFile>();
            
            /* loop through input data and build output */
            foreach (InputFile1 item in InputDataSet)
            {
                TargetFile _outfile = new TargetFile();

                /* make decisions what to do for translated data */

                string[] _identifier = item.Identifier.Split('|');
                _outfile.Id = Convert.ToInt32(_identifier[0]); // first value is "Id"
                _outfile.AccountCode = _identifier[1]; // second value is "Account Code"

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
                _outfile.OpenedDate = DateTime.Parse(item.Opened);

                /* currency */
                if (item.Currency == "US")
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

        /*
        public IActionResult Edit(int row = 1)
        {
            var _rowData = GetRowNum(row);
            ViewData["Row"] = _rowData;

            return View("Edit");
        }

        public InputFile1 GetRowNum(int Row)
        {
            var _dataSet = BuildDataSet();

            InputFile1 _row = _dataSet[Row];

            return _row;
        }
        public XmlSerializer GetSerializer()
        {
            var _serializer = new System.Xml.Serialization.XmlSerializer(typeof(InputFile1));
            return _serializer;
        }*/

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
