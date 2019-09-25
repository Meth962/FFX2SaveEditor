using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFX2SaveEditor
{
    public static class Utils
    {
        public static double RadianToDegree(double angle)
        {
            return angle * (180.0 / Math.PI);
        }

        public static byte[] BoolsToBytes(bool[] bools)
        {
            var bytes = new byte[bools.Length / 8];
            for (int b = 0; b < bytes.Length; b++)
            {
                for (int bit = 0; bit < 8; bit++)
                {
                    if (bools[b + bit])
                        bytes[b] &= (byte)Math.Pow(2, bit);
                }
            }
            return bytes;
        }
    }

    public static class Extensions
    {
        public static void Write(this BinaryWriter bw, bool[] bools)
        {
            bw.Write(Utils.BoolsToBytes(bools));
        }

        public static void Write(this BinaryWriter bw, int offset, short value)
        {
            bw.BaseStream.Seek(offset, SeekOrigin.Begin);
            bw.Write(value);
        }
    }
}
