using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Needle.Structure
{
    public class Settings
    {
        public static int entrypoint = 0;
        public static int endpoint = 647;

        public class Header
        {
            public static int size = 264;
            public static int header = Address.Header.head.size;
            public static int version = Address.Header.version.size;
            public static int security = Address.Header.security.size;
            public static int key = Address.Header.key.size;
        }

        public class Body
        {
            public class Credentials
            {
                public static int username = Address.Body.Credentials.username.size;
                public static int discord = Address.Body.Credentials.discord.size;
                public static int id = Address.Body.Credentials.id.size;
            }

            public class Authorization
            {
                public static int client = Address.Body.Authorization.client.size;
                public static int versions = Address.Body.Authorization.versions.size;
            }
        }
    }
}
