using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Needle.Signature
{
    public class Signature
    {
        public static byte[] sign(byte[] key)
        {
            List<byte> authentification = new List<byte>();
            Dictionary<byte, int> buffer = new Dictionary<byte, int>();
            Dictionary<byte, int> dic = new Dictionary<byte, int>();

            foreach (byte b in key)
            {
                if (buffer.ContainsKey(b) == false)
                    buffer.Add(b, buffer.Count);
                if (dic.ContainsKey(b) == false)
                    dic.Add(b, 1);
                else
                    dic[b]++;
                authentification.Add((byte)shift(b, (buffer.Count + dic[b])));
            }

            return (authentification.ToArray());
        }

        private static int shift(int a, int b)
        {
            a ^= a << 23;
            a ^= a >> 18;
            a ^= b;
            a ^= b >> 5;

            return (a + b);
        }
    }
}
