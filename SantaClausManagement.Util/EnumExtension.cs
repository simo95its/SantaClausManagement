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
            var attr = GetDisplayAttribute(e);
            return attr != null ? attr.Name : e.ToString();
        }

        private static DisplayAttribute GetDisplayAttribute(object value)
        {
            Type type = value.GetType();
            var field = type.GetField(value.ToString());
            return field == null ? null : field.GetCustomAttribute<DisplayAttribute>();
        }
    }
}
