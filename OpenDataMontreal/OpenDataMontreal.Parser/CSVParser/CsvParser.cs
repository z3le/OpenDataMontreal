using OpenDataMontreal.Models;
using OpenDataMontreal.Parser.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyCsvParser;
using TinyCsvParser.Mapping;

namespace OpenDataMontreal.Parser.CSVParser
{
    public class CsvParser
    {
        public List<CsvMappingResult<CrimesModel>> Test(string csvFile)
        {
            CsvParserOptions csvParserOptions = new CsvParserOptions(true, new[] { ';' });
            CsvReaderOptions csvReaderOptions = new CsvReaderOptions(new[] { Environment.NewLine });
            CsvCrimesMapping csvMapper = new CsvCrimesMapping();
            CsvParser<CrimesModel> csvParser = new CsvParser<CrimesModel>(csvParserOptions, csvMapper);

            var result = csvParser
                .ReadFromString(csvReaderOptions, csvFile)
                .ToList();

            return result;
        }
    }
}
