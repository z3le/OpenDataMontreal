using System;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenDataMontreal.Models;
using OpenDataMontreal.Parser.CSVParser;
using OpenDataMontreal.Parser.Mappers;
using TinyCsvParser;

namespace OpenDataMontrealTests
{
    [TestClass]
    public class CsvFileParserTests
    {
        [TestMethod]
        public void CsvFileParserTests_CrimeMapper()
        {
           var csvParser = new CsvFileParser<CrimesModel>(',');
           var mapper = new CsvCrimesMapping();

            var stringBuilder = new StringBuilder()
                .AppendLine("CATEGORIE,DATE,QUART,PDQ,X,Y,LAT,LONG")
                .AppendLine("Infractions entrainant la mort,2016-07-12 00:00:00,nuit,11,293385.951991999990000,5036700.743999999900000,45.470140598599997,-73.645975478200000");

            var result = csvParser.ParseCsvString(stringBuilder.ToString(), mapper).Select(x => x.Result).FirstOrDefault();
            var validResult = new CrimesModel()
            {
                Category = "Infractions entrainant la mort",
                Date = new DateTime(2016, 7, 12),
                DayPart = "nuit",
                PostNumber = 11,
                CoordinateX = 293385.951991999990000,
                CoordinateY = 5036700.743999999900000,
                Latitude = 45.470140598599997,
                Longitude = -73.645975478200000
            };

            Assert.AreEqual(validResult.Category, result.Category);
            Assert.AreEqual(validResult.Date.Date, result.Date.Date);
            Assert.AreEqual(validResult.DayPart, result.DayPart);
            Assert.AreEqual(validResult.PostNumber, result.PostNumber);
            Assert.AreEqual(validResult.CoordinateX, result.CoordinateX);
            Assert.AreEqual(validResult.CoordinateY, result.CoordinateY);
            Assert.AreEqual(validResult.Latitude, result.Latitude);
            Assert.AreEqual(validResult.Longitude, result.Longitude);
        }
    }
}
