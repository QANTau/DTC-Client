using System;

namespace QANT.DTC
{
    public static partial class Utils
    {
        /// <summary>
        /// Current UNIX DateTime (UTC)
        /// </summary>
        /// <returns></returns>
        public static long CurrentUnixDateTime()
        {
            return (long)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;
        }

        /// <summary>
        /// UNIX DateTime
        /// </summary>
        /// <param name="windowsDt"></param>
        /// <returns></returns>
        public static int UnixDateTime(DateTime windowsDt)
        {
            return (int)(windowsDt - new DateTime(1970, 1, 1)).TotalSeconds;
        }

        /// <summary>
        /// UNIX DateTime
        /// </summary>
        /// <param name="windowsDt"></param>
        /// <returns></returns>
        public static long UnixDateTimeMsec(DateTime windowsDt)
        {
            return (long) (windowsDt - new DateTime(1970, 1, 1)).TotalMilliseconds;
        }

        /// <summary>
        /// Convert UNIX DateTime to Windows DateTime
        /// </summary>
        public static DateTime WindowsDateTime(double unixDt)
        {
            var dt = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dt = dt.AddSeconds(unixDt).ToUniversalTime();
            return dt;
        }
    }
}
