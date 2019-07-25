using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeslaCamViewer
{
    public class TeslaCamDate
    {
        private const string FileFormatNoSeconds = "yyyy-MM-dd_HH-mm";
        private const string FileFormatWithSeconds = "yyyy-MM-dd_HH-mm-ss";
        private const string DisplayFormatNoSeconds = "M/d/yyyy h:mm tt";
        private const string DisplayFormatWithSeconds = "M/d/yyyy h:mm:ss tt";

        public string UTCDateString { get; private set; }
        public string DisplayValue
        {
            get
            {
                if (UTCTimeStamp.Second == 0) return LocalTimeStamp.ToString(DisplayFormatNoSeconds);
                return LocalTimeStamp.ToString(DisplayFormatWithSeconds);
            }
        }
        public DateTime UTCTimeStamp
        {
            get
            {
                DateTime dt;
                if (DateTime.TryParseExact(UTCDateString, FileFormatNoSeconds, CultureInfo.InvariantCulture, DateTimeStyles.None, out dt)) return dt;
                if (DateTime.TryParseExact(UTCDateString, FileFormatWithSeconds, CultureInfo.InvariantCulture, DateTimeStyles.None, out dt)) return dt;
                throw new Exception("Invalid date format: " + UTCDateString);
            }
        }
        public DateTime LocalTimeStamp
        {
            get
            {
                return UTCTimeStamp;
            }
        }

        public TeslaCamDate(string DateString)
        {
            UTCDateString = DateString;
        }

    }
}
