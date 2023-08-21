using System.Text;

namespace basicwebapi.constants
{
    public class Utilities
    {
        static public string EncodeToBase64(string? value=null, byte[] ?valuebytes=null)
        {
            return  Convert.ToBase64String(value!=null? Encoding.UTF8.GetBytes(value):valuebytes);
        }
        static public string DecodeBase64(string value)
        {
            return Encoding.UTF8.GetString((Convert.FromBase64String(value)));
        }
        public static TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
    }
}
