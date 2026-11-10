using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Museum_Management_Utilities.FileHandler
{
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class ExcelIgnoreAttribute : Attribute
    {
    }
}
