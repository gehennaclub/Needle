using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Needle
{
    public class Format
    {
        public Header header { get; set; }
        public Body body { get; set; }
        public Signature signature { get; set; }

        public class Header
        {
            public enum Security : byte
            {
                none = 0x0,
                hidden = 0x1,
                salty = 0x2
            };

            public byte[] head { get; set; }
            public byte[] version { get; set; }
            public byte[] key { get; set; }
            public Security security { get; set; }
        }

        public class Body
        {
            public Authorization authorization { get; set; }
            public Credentials credentials { get; set; }

            public class Credentials
            {
                public byte[] username { get; set; }
                public byte[] discord { get; set; }
                public byte[] id { get; set; }
            }

            public class Authorization
            {
                public byte[] versions { get; set; }
            }
        }

        public class Signature
        {
            public byte[] signature { get; set; }
        }
    }
}
