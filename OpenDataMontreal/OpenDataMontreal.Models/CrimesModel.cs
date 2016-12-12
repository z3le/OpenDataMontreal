using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenDataMontreal.Models
{
    public class CrimesModel
    {
        public string Categorie { get; set; }

        public DateTime Date { get; set; }

        public string DayPart { get; set; }

        public string PostNumber { get; set; }

        public float CoordinateX { get; set; }

        public float CoordinateY { get; set; }

        public float Longitude { get; set; }
    }
}
