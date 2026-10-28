using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_Models.ConfigurationManagement
{
    public class Allcode_model : Datatable_model
    {
        public int ALLCODE_ID { get; set; }
        public string? CDNAME { get; set; }
        public string? CDTYPE { get; set; }
        public string? CD_VAL { get; set; }
        public string? CONTENT { get; set; }
    }
}
