using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Linq;

namespace ExtensionMethodCSharp.Enums
{
    /// <summary>
    /// TestEnum
    /// </summary>
    public enum ExchangeRateType
    {
        Fixed = 0,
        [Display(Name = "Alternating Current")]
        ByDay = 1
    }
}
