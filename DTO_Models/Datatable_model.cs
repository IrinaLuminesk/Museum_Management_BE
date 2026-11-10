using Museum_Management_Utilities.FileHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_Models
{
    public class Datatable_model
    {
        [ExcelIgnore]
        public int PageNumber { get; set; } = 1;
        [ExcelIgnore]
        public int PageSize { get; set; } = 10;
        [ExcelIgnore]
        public string? SortColumn { get; set; }
        [ExcelIgnore]
        public string? SortDirection { get; set; }
    }
}
