using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Needle.Client
{
    public class Client
    {
        public Structure.Key key { get; set; }
        private States state { get; set; }

        public void feed(byte[] bytes)
        {
            key = new Structure.Key();
            state = new States(false);


            if (Validator.size(bytes, Structure.Settings.endpoint) == true)
            {
                load_header(bytes);
                load_body(bytes);
            }
        }

        private void load_header(byte[] bytes)
        {
            Structure.Key.Header header = new Structure.Key.Header()
            {
                head = bytes.Skip(Structure.Address.Header.head.start).Take(Structure.Address.Header.head.size).ToArray(),
                version = bytes.Skip(Structure.Address.Header.version.start).Take(Structure.Address.Header.version.size).ToArray(),
                security = (Structure.Key.Header.Security)bytes[Structure.Address.Header.security.start],
                key = bytes.Skip(Structure.Address.Header.key.start).Take(Structure.Address.Header.key.size).ToArray()
            };

            key.header = header;
        }

        private void load_body(byte[] bytes)
        {
            Structure.Key.Body body = new Structure.Key.Body();

            body.credentials = new Structure.Key.Body.Credentials()
            {
                username = bytes.Skip(Structure.Address.Body.Credentials.username.start).Take(Structure.Address.Body.Credentials.username.size).ToArray(),
                discord = bytes.Skip(Structure.Address.Body.Credentials.discord.start).Take(Structure.Address.Body.Credentials.discord.size).ToArray(),
                id = bytes.Skip(Structure.Address.Body.Credentials.id.start).Take(Structure.Address.Body.Credentials.id.size).ToArray()
            };

            body.authorization = new Structure.Key.Body.Authorization()
            {
                client = bytes.Skip(Structure.Address.Body.Authorization.client.start).Take(Structure.Address.Body.Authorization.client.size).ToArray(),
                versions = bytes.Skip(Structure.Address.Body.Authorization.versions.start).Take(Structure.Address.Body.Authorization.versions.size).ToArray()
            };

            key.body = body;
        }
    }
}
