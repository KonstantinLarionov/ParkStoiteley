using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkStroiteleyMVC.Models.Extensions
{
    public static class StringExtension
    {
        public static string ToPreview(this string str)
        {
            if (str.Length > 95)
            {
                var cstr = str.Take(95).ToList(); cstr.Add('.'); cstr.Add('.'); cstr.Add('.');

                return cstr.ToString();
            }
            else
            {
                return str + "...";
            }
        }
        public static int ToInt(this string str)
        {
            try
            {
                return Convert.ToInt32(str);
            }
            catch
            {
                return 0;
            }
        }
        public static double ToDouble(this string str)
        {
            try
            {
                return Convert.ToDouble(str.Replace(".", ","));
            }
            catch
            {
                return 0;
            }
        }
    }
}
