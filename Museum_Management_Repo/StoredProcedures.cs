using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Museum_Management_Repositories
{
    public static class StoredProcedures
    {
        #region Master Data
        public static class Museum
        {
            
            public const string MUSEUM_SEARCH = "MD_MUSEUM_SEARCH";
            public const string MUSEUM_GETBYID = "MD_MUSEUM_GETBYID";
            public const string MUSEUM_CREATE = "MD_MUSEUM_CREATE";
            public const string MUSEUM_EDIT = "MD_MUSEUM_EDIT";
            public const string MUSEUM_DELETE = "MD_MUSEUM_DELETE";

        }
        #endregion

        #region Configuration Management
        public static class Allcode
        {

            public const string ALLCODE_SEARCH = "CM_ALLCODE_SEARCH";
            public const string ALLCODE_GETBYID = "CM_ALLCODE_GETBYID";
            public const string ALLCODE_EDIT = "CM_ALLCODE_EDIT";
            public const string ALLCODE_CREATE = "CM_ALLCODE_CREATE";

        }
        #endregion

    }
}
