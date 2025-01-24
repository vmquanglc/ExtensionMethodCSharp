using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Mail;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ExtensionMethodCSharp
{
    /// <summary>
    /// Hàm xử lý số
    /// </summary>
    public static class ExtensionUtility
    {
        #region Xử lý string
        public static string RemoveSignChar(this string text)
        {
            if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(text.Trim()))
            {
                return text;
            }
            var result = text;
            try
            {
                var originalChar = new string[] { "ÁÀẢÃẠÂẤẦẨẪẬĂẮẰẲẴẶ", "ÉÈẺẼẸÊẾỀỂỄỆ", "ÍÌỈĨỊ", "ÓÒỎÕỌÔỐỒỔỖỘƠỚỜỞỠỢ", "ÚÙỦŨỤƯỨỪỬỮỰ", "ÝỲỶỸỴ", "Đ" };
                var replaceChar = new string[] { "A", "E", "I", "O", "U", "Y", "D" };
                for (int i = 0; i < originalChar.Length; i++)
                {
                    var reg = new Regex("[" + originalChar[i] + "]");
                    result = reg.Replace(result, replaceChar[i]);
        
                    reg = new Regex("[" + originalChar[i].ToLower() + "]");
                    result = reg.Replace(result, replaceChar[i].ToLower());
                }
            }
            catch (Exception ex)
            {
        
            }
            return result;
        }
        #endregion
        
        #region Enum
        public static string GetDisplayName(this Enum enumType)
        {
            string result = string.Empty;
            try
            {
                result = enumType.GetType()?.GetMember(enumType.ToString())?
                               .First()?
                               .GetCustomAttribute<DisplayAttribute>()?
                               .Name ?? enumType.ToString();
            }
            catch (Exception ex)
            {
                //
            }
            return result;
        }
        #endregion
        
        #region datetime
        public static DateTime GetFirstOfDay(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day);
        }
        public static DateTime GetLastOfDay(this DateTime date)
        {
            return date.GetFirstOfDay().AddDays(1).AddMilliseconds(-1);
        }
        public static DateTime GetFirstOfWeek(this DateTime date)
        {
            var diffVsBegin = 0;
            if (date.DayOfWeek == DayOfWeek.Sunday)
            {
                diffVsBegin = 6;
            }
            else
            {
                diffVsBegin = date.DayOfWeek - DayOfWeek.Monday;
            }
            var firstDayOfWeek = date.AddDays(-diffVsBegin);
            return new DateTime(firstDayOfWeek.Year, firstDayOfWeek.Month, firstDayOfWeek.Day);
        }
        public static DateTime GetLastOfWeek(this DateTime date)
        {
            return date.GetFirstOfWeek().AddDays(7).AddMilliseconds(-1);
        }
        public static DateTime GetFirstDayOfMonth(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, 1);
        }
        public static DateTime GetLastDayOfMonth(this DateTime date)
        {
            return date.GetFirstDayOfMonth().AddMonths(1).AddTicks(-1);
        }
        public static DateTime GetFirstDayOfYear(this DateTime date)
        {
            return new DateTime(date.Year, 1, 1);
        }
        public static DateTime GetLastDayOfYear(this DateTime date)
        {
            return date.GetFirstDayOfYear().AddYears(1).AddTicks(-1);
        }
        #endregion
    }
}
