using System;
using System.Text;

namespace QANT.DTC
{
    public static partial class Utils
    {
        /// <summary>
        /// Convert byte[] to String
        /// </summary>
        /// <param name="obj">Array</param>
        /// <returns>String</returns>
        public static string GetString(byte[] obj)
        {
            return Encoding.UTF8.GetString(obj);
        }

        /// <summary>
        /// Convert byte[] to String with Removal of Nulls
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string GetCleanString(byte[] obj)
        {
            string result = "";

            foreach (byte item in obj)
            {
                if (item == 0)
                    continue;
                result += Convert.ToChar(item);
            }

            return result;
        }

        /// <summary>
        /// Convert String to byte[]
        /// </summary>
        /// <param name="obj">String</param>
        /// <returns>byte[]</returns>
        public static byte[] GetBytes(string obj)
        {
            return Encoding.ASCII.GetBytes(obj);
        }

        /// <summary>
        /// Convert String to Fixed-Length byte[] (Null Terminated)
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static byte[] AsPaddedBytes(string obj, int length)
        {
            // Check for Null String (Empty String is OK)
            if (String.IsNullOrEmpty(obj))
                obj = "";

            var working = obj;

            if (working.Length > length)
                working = working.Substring(0, length);

            if (working.Length == length)
                return GetBytes(working);
            var nullterminator = new byte[] { 0 };

            var data = GetBytes(working);

            for (int x = obj.Length; x < length; x++)
            {
                data = Combine(data, nullterminator);
            }

            return data;
        }
    }
}
