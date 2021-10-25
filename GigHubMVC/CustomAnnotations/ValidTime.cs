using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace GigHubMVC.CustomAnnotations
{
    public class ValidTime : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime Time;
            var isValid = DateTime.TryParseExact(Convert.ToString(value), 
                "HH:mm",
                DateTimeFormatInfo.InvariantInfo, DateTimeStyles.None,
                out Time);

            return (isValid);
        }
        
    }
}