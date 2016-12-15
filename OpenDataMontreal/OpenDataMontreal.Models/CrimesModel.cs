﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenDataMontreal.Models
{
    public class CrimesModel
    {
        public string Category { get; set; }

        public DateTime Date { get; set; }

        public string DayPart { get; set; }

        public int PostNumber { get; set; }

        public double CoordinateX { get; set; }

        public double CoordinateY { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }
    }
}
