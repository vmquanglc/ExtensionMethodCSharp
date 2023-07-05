using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethodCSharp
{
    /// <summary>
    /// Hàm validate dữ liệu
    /// </summary>
    public static class ValidateUtility
    {
        #region Validate,Check Int,Bool,Decimal,...
        /// <summary>
        /// is Decimal
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsDecimal(this object value)
        {
            try
            {
                return decimal.TryParse(value.ToString(), out decimal result);
            }
            catch
            {
                //do something if catch
            }
            return false;
        }
        #endregion

        #region Validate Email,Taxcode,Phone...
        public static bool IsEmail(this string email)
        {
            try
            {
                var emailAddress = new MailAddress(email);
                return true;
            }
            catch
            {
                //dosomething
            }
            return false;
        }
        #endregion
    }
}
