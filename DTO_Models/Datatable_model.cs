using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_Models
{
    public class Datatable_model
    {
        public int PageNumber { get; set; } = 1;

        public int PageSize { get; set; } = 10;
            
        public string? SortColumn { get; set; }
        public string? SortDirection { get; set; }
    }
}
