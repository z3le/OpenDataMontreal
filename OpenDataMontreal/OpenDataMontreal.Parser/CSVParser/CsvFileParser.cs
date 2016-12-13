using System;
using System.Collections.Generic;
using System.Linq;
using TinyCsvParser;
using TinyCsvParser.Mapping;

namespace OpenDataMontreal.Parser.CSVParser
{
    public class CsvFileParser<T> where T : class, new()
    {
        private CsvParserOptions _csvParserOptions;
        private CsvReaderOptions _csvReaderOptions;

        public CsvFileParser(char fieldsSeparator)
        {
            _csvParserOptions = new CsvParserOptions(true, new[] { fieldsSeparator });
            _csvReaderOptions = new CsvReaderOptions(new[] { Environment.NewLine });
        }

        public List<CsvMappingResult<T>> ParseCsvString(string csvFile, CsvMapping<T> mapper)
        {
            var csvParser = new CsvParser<T>(_csvParserOptions, mapper);

            var result = csvParser
                .ReadFromString(_csvReaderOptions, csvFile)
                .ToList();

            return result;
        }
    }
}
