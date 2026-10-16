using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DTO_Models.MasterData
{
    public class Museum_model
    {
        public int? MUSEUM_ID { get; set; }

        public string? MUSEUM_NAME { get; set; }
        public string? ADDRESS { get; set; }
        public string? CITY { get; set; }
        public string? STATE { get; set; }
        public string? POSTAL { get; set; }
        public string? COUNTRY { get; set; }
        public string? PHONE { get; set; }
        public string? URL { get; set; }
    }
}
