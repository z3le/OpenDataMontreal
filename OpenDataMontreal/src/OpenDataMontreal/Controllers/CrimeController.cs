using DataTables.AspNet.AspNetCore;
using DataTables.AspNet.Core;
using GeoJSON.Net.Feature;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using OpenDataMontreal.Extensions;
using OpenDataMontreal.Helpers;
using OpenDataMontreal.Models;
using OpenDataMontreal.Models.GoogleMaps;
using OpenDataMontreal.Parser.CSVParser;
using OpenDataMontreal.Parser.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace OpenDataMontreal.Controllers
{
    public class CrimeController : Controller
    {
        private readonly CsvFileParser<CrimesModel> _parser;
        private readonly UrlSettings _settings;
        private readonly CsvCrimesMapping _mapper;

        public CrimeController(IOptions<UrlSettings> settings)
        {
            _settings = settings.Value;
            _parser = new CsvFileParser<CrimesModel>(',');
            _mapper = new CsvCrimesMapping();
        }

        // GET: /<controller>/
        [Route("/[controller]")]
        public IActionResult Index()
        {
            using (var client = new HttpClient())
            {
                var getCrimesCsv = client.GetAsync(_settings.CrimesUrl).Result.Content.ReadAsStringAsync().Result;
                var data = _parser.ParseCsvString(getCrimesCsv, _mapper).Select(x => x.Result).ToList();
                HttpContext.Session.SetObjectAsJson("crimes", data);
                return View(data);
            }
        }

        public IActionResult PageData(IDataTablesRequest request)
        {
            var data = HttpContext.Session.GetObjectFromJson<List<CrimesModel>>("crimes");
            var filteredData = String.IsNullOrWhiteSpace(request.Search.Value)
                ? data
                : data.Where(_item => _item.Category.Contains(request.Search.Value));
            var dataPage = filteredData.Skip(request.Start).Take(request.Length);

            var response = DataTablesResponse.Create(request, data.Count(), filteredData.Count(), dataPage);
            return new DataTablesJsonResult(response, true);
        }
    }
}
