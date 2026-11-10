using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_Models.Response
{
    public class Export_model
    {
        public List<string>? headers { get; set; }

        public List<string>? columnId { get; set; }

        public string? reportName { get; set; }
    }
}
