using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using OpenDataMontreal.Helpers;
using OpenDataMontreal.Models;
using OpenDataMontreal.Parser.CSVParser;
using OpenDataMontreal.Parser.Mappers;
using System.Net.Http;

namespace OpenDataMontreal.Controllers
{
    public class CrimeController : Controller
    {
        private CsvFileParser<CrimesModel> _parser;
        private readonly UrlSettings _settings;
        private CsvCrimesMapping _mapper;

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
                var getCrimesCsv =  client.GetAsync(_settings.CrimesUrl).Result.Content.ReadAsStringAsync().Result;
                var mappedCrimes = _parser.ParseCsvString(getCrimesCsv, _mapper);
                return View(mappedCrimes);
            }
        }
    }
}
