using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SkyCloudStorage.Modules {
    internal class Fingerprint {
        public Fingerprint()
        {
            string s = GetHash("");
        }

        private string GetHash(string source)
        {
            StringBuilder stringBuilder = new StringBuilder();

            using (MD5 mD5 = MD5.Create())
            {
                byte[] data = mD5.ComputeHash(Encoding.UTF8.GetBytes(source));
                
                for (int i = 0; i < data.Length; i++)
                {
                    stringBuilder.Append(data[i].ToString("x2"));
                }
            }
            return stringBuilder.ToString().ToUpper();
        }
    }
}
