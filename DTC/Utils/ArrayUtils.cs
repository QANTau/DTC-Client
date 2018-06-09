using System;
using System.Collections.Generic;

namespace QANT.DTC
{
    public static partial class Utils
    {
        /// <summary>
        /// Combine byte[] Arrays
        /// </summary>
        /// <param name="a01">Array</param>
        /// <param name="a02">Array</param>
        /// <returns>Combined Arrays</returns>
        public static byte[] Combine(byte[] a01, byte[] a02)
        {
            // a01 + a02
            var result = new byte[a01.Length + a02.Length];
            Buffer.BlockCopy(a01, 0, result, 0, a01.Length);
            Buffer.BlockCopy(a02, 0, result, a01.Length, a02.Length);
            return result;
        }

        /// <summary>
        /// Combine byte[] Arrays
        /// </summary>
        /// <param name="a01">Array</param>
        /// <param name="a02">Array</param>
        /// <param name="a03">Array</param>
        /// <returns>Combined Arrays</returns>
        public static byte[] Combine(byte[] a01, byte[] a02, byte[] a03)
        {
            // a01 + a02 + a03
            return Combine(a01, Combine(a02, a03));
        }

        /// <summary>
        /// Combine byte[] Arrays
        /// </summary>
        /// <param name="a01">Array</param>
        /// <param name="a02">Array</param>
        /// <param name="a03">Array</param>
        /// <param name="a04">Array</param>
        /// <returns>Combined Arrays</returns>
        public static byte[] Combine(byte[] a01, byte[] a02, byte[] a03, byte[] a04)
        {
            // a01 + a02 + a03
            return Combine(a01, Combine(a02, Combine(a03, a04)));
        }

        /// <summary>
        /// Combine byte[] Arrays
        /// </summary>
        /// <param name="a01">Array</param>
        /// <param name="a02">Array</param>
        /// <param name="a03">Array</param>
        /// <param name="a04">Array</param>
        /// <param name="a05">Array</param>
        /// <returns>Combined Arrays</returns>
        public static byte[] Combine(byte[] a01, byte[] a02, byte[] a03, byte[] a04, byte[] a05)
        {

            // a01 + a02 + a03 + a04 + a05

            var l = Combine(a01, Combine(a02, a03));
            var r = Combine(a04, a05);

            return Combine(l, r);
        }

        /// <summary>
        /// Combine byte[] Arrays
        /// </summary>
        /// <param name="a01">Array</param>
        /// <param name="a02">Array</param>
        /// <param name="a03">Array</param>
        /// <param name="a04">Array</param>
        /// <param name="a05">Array</param>
        /// <param name="a06">Array</param>
        /// <param name="a07">Array</param>
        /// <param name="a08">Array</param>
        /// <param name="a09">Array</param>
        /// <param name="a10">Array</param>
        /// <returns>Combined Arrays</returns>
        public static byte[] Combine(byte[] a01, byte[] a02, byte[] a03, byte[] a04, byte[] a05, byte[] a06,
            byte[] a07, byte[] a08, byte[] a09, byte[] a10)
        {

            // a01 + a02 + a03 + a04 + a05 + a06 + a07 + a08 + a09 + a10

            var p1 = Combine(a01, Combine(a02, a03));
            var p2 = Combine(a04, Combine(a05, a06));
            var p3 = Combine(a07, Combine(a08, a09));

            var l = Combine(p1, p2);
            var r = Combine(p3, a10);

            return Combine(l, r);
        }

        /// <summary>
        /// Combine byte[] Arrays
        /// </summary>
        /// <param name="a01">Array</param>
        /// <param name="a02">Array</param>
        /// <param name="a03">Array</param>
        /// <param name="a04">Array</param>
        /// <param name="a05">Array</param>
        /// <param name="a06">Array</param>
        /// <param name="a07">Array</param>
        /// <param name="a08">Array</param>
        /// <param name="a09">Array</param>
        /// <param name="a10">Array</param>
        /// <param name="a11">Array</param>
        /// <returns>Combined Arrays</returns>
        public static byte[] Combine(byte[] a01, byte[] a02, byte[] a03, byte[] a04, byte[] a05, byte[] a06,
            byte[] a07, byte[] a08, byte[] a09, byte[] a10, byte[] a11)
        {

            // a01 + a02 + a03 + a04 + a05 + a06 + a07 + a08 + a09 + a10 + a11

            var p1 = Combine(a01, Combine(a02, a03));
            var p2 = Combine(a04, Combine(a05, a06));
            var p3 = Combine(a07, Combine(a08, a09));
            var p4 = Combine(a10, a11);

            var l = Combine(p1, p2);
            var r = Combine(p3, p4);

            return Combine(l, r);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="delimiter"></param>
        /// <returns>Code originally from https://stackoverflow.com/questions/9755090/split-a-byte-array-at-a-delimiter</returns>
        public static List<byte[]> SplitBytesByDelimiter(byte[] data, byte delimiter)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));
            if (data.Length < 1) return null;

            var retList = new List<byte[]>();

            var start = 0;
            var pos = 0;
            byte[] remainder = null;

            while (true)
            {
                if (pos >= data.Length) break;

                if (data[pos] == delimiter)
                {
                    // Separator Found
                    if (pos == start)
                    {
                        pos++;
                        start++;
                        if (pos >= data.Length)
                        {
                            remainder = null;
                            break;
                        }

                        remainder = new byte[data.Length - start];
                        Buffer.BlockCopy(data, start, remainder, 0, (data.Length - start));
                    }
                    else
                    {
                        var ba = new byte[(pos - start)];
                        Buffer.BlockCopy(data, start, ba, 0, (pos - start));
                        retList.Add(ba);

                        start = pos + 1;
                        pos = start;

                        if (pos >= data.Length)
                        {
                            remainder = null;
                            break;
                        }

                        remainder = new byte[data.Length - start];
                        Buffer.BlockCopy(data, start, remainder, 0, (data.Length - start));
                    }
                }
                else
                {
                    pos++;
                }
            }

            if (remainder != null)
            {
                retList.Add(remainder);
            }

            return retList;
        }
    }
}
