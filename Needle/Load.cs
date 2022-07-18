using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Needle
{
    public class Load
    {
        public Format format = new Format();

        public Load(byte[] key, byte[] signature)
        {
            load_header(key);
            load_body(key);
            // load_signature(signature);
        }

        private void load_header(byte[] bytes)
        {
            Format.Header header = new Format.Header()
            {
                head = bytes.Skip(Address.Header.head.start).Take(Address.Header.head.size).ToArray(),
                version = bytes.Skip(Address.Header.version.start).Take(Address.Header.version.size).ToArray(),
                security = (Format.Header.Security)bytes[Address.Header.security.start],
                key = bytes.Skip(Address.Header.key.start).Take(Address.Header.key.size).ToArray()
            };

            format.header = header;
        }

        private void load_body(byte[] bytes)
        {
            Format.Body body = new Format.Body();

            body.credentials = new Format.Body.Credentials()
            {
                username = bytes.Skip(Address.Body.Credentials.username.start).Take(Address.Body.Credentials.username.size).ToArray(),
                discord = bytes.Skip(Address.Body.Credentials.discord.start).Take(Address.Body.Credentials.discord.size).ToArray(),
                id = bytes.Skip(Address.Body.Credentials.id.start).Take(Address.Body.Credentials.id.size).ToArray()
            };

            body.authorization = new Format.Body.Authorization()
            {
                versions = bytes.Skip(Address.Body.Authorization.versions.start).Take(Address.Body.Authorization.versions.size).ToArray()
            };

            format.body = body;
        }

        private void load_signature(byte[] bytes)
        {
            
        }
    }
}
