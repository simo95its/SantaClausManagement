using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SantaClausManagement.Util
{
    public static class EnumExtension
    {
        public static string GetDisplayName(this Enum e)
        {
            Type type = e.GetType();
            var field = type.GetField(e.ToString());
            var attr = (field == null ? null : field.GetCustomAttribute<DisplayAttribute>());
            return attr != null ? attr.Name : e.ToString();
        }
    }
}
