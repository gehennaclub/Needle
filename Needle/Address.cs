using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Needle
{
    public class Address
    {
        public class Header
        {
            public static Offset head = new Offset(Settings.entrypoint, 3);
            public static Offset version = new Offset(Header.head.next, 3);
            public static Offset security = new Offset(Header.version.next, 1, true);
            public static Offset key = new Offset(Header.security.next, 256);
        }

        public class Body
        {
            public class Credentials
            {
                public static Offset username = new Offset(Header.key.next, 32);
                public static Offset discord = new Offset(Credentials.username.next, 32);
                public static Offset id = new Offset(Credentials.discord.next, 128);
            }

            public class Authorization
            {
                public static Offset versions = new Offset(Credentials.id.next, 128);
            }
        }
    }
}
