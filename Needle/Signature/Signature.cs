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
            List<byte> authentification = new List<byte>()
            {
               78,
               68,
               76,
               83,
               0x00
            };
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
                authentification.Add((byte)shift32(dic[b]));
                authentification.Add((byte)shift128(b, (buffer.Count)));
            }

            return (authentification.ToArray());
        }

        private static int shift128(int a, int b)
        {
            a ^= a << 23;
            a ^= a >> 18;
            a ^= b;
            a ^= b >> 5;

            return (a + b);
        }

        private static int shift32(int x)
        {
            x ^= x << 13;
            x ^= x >> 17;
            x ^= x << 5;

            return (x);
        }

        public static bool validate(byte[] key, byte[] signature)
        {
            byte[] safe = Signature.sign(key);

            if (signature.Length == safe.Length)
            {
                for (int i = 0; i < safe.Length; i++)
                {
                    if (signature[i] != safe[i])
                        return (false);
                }
                return (true);
            }

            return (false);
        }
    }
}
