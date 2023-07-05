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
        /// <summary>
        /// Bỏ dấu tiếng Việt
        /// </summary>
        /// <param name="text">value</param>
        /// <returns>Chuỗi đã bỏ dấu</returns>
        public static string RemoveVNSignV1(this string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return string.Empty;
            }

            System.Text.StringBuilder result = new System.Text.StringBuilder();
            string temp = text;
            temp = temp.Replace("&", " ");
            
            //replace đối với đ Đ
            temp = Regex.Replace(temp, "Đ", "D");
            temp = Regex.Replace(temp, "đ", "d");

            // normalize the Unicode
            temp = temp.Normalize(System.Text.NormalizationForm.FormKD);
            foreach (char s in temp)
            {
                if ((char.GetUnicodeCategory(s) != UnicodeCategory.NonSpacingMark) && !(char.IsPunctuation(s)) && !(char.IsSymbol(s)))
                {
                    result.Append(s);
                }
            }
            return result.ToString();
        }
        public static string RemoveVNSignV2(this string text)
        {
            var result = text;
            if (!string.IsNullOrWhiteSpace(text))
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
            return result;
        }
        #endregion

        #region Enum
        /// <summary>
        /// Get displayname theo enum
        /// </summary>
        /// <param name="enumType"></param>
        /// <returns></returns>
        public static string GetEnumDisplayName(this Enum enumType)
        {
            string result = string.Empty;
            try
            {
                result = enumType?.GetType()?.GetMember(enumType.ToString())?
                               .First()?
                               .GetCustomAttribute<System.ComponentModel.DataAnnotations.DisplayAttribute>()?
                               .Name ?? string.Empty;
            }
            catch (Exception ex)
            {
                //
            }
            return result;
        }
        #endregion
    }
}
