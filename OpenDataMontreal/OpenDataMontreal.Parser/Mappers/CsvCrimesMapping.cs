using OpenDataMontreal.Models;
using TinyCsvParser.Mapping;

namespace OpenDataMontreal.Parser.Mappers
{
    public class CsvCrimesMapping : CsvMapping<CrimesModel>
    {
        public CsvCrimesMapping() : base()
        {
            MapProperty(0, x => x.Categorie);
            MapProperty(1, x => x.Date);
            MapProperty(2, x => x.DayPart);
            MapProperty(3, x => x.PostNumber);
            MapProperty(4, x => x.CoordinateX);
            MapProperty(5, x => x.CoordinateY);
            MapProperty(6, x => x.Longitude);
        }
    }
}
