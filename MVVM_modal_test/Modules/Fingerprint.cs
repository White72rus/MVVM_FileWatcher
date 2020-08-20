using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SkyCloudStorage.Modules {
    internal class Fingerprint {
        public Fingerprint()
        {
            string s = GetHash("");
            GetProcessorInfo();
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

        private void GetProcessorInfo()
        {
            try
            {
                ManagementObjectSearcher searcher =
                    new ManagementObjectSearcher("root\\CIMV2",
                    "SELECT * FROM Win32_Processor");

                foreach (ManagementObject queryObj in searcher.Get())
                {
                    Console.WriteLine("Caption: {0}", queryObj["Caption"]);
                    Console.WriteLine("SocketDesignation: {0}", queryObj["SocketDesignation"]);
                    Console.WriteLine("Revision: {0}", queryObj["Revision"]);
                    Console.WriteLine("ProcessorId: {0}", queryObj["ProcessorId"]);
                    Console.WriteLine("NumberOfCores: {0}", queryObj["NumberOfCores"]);
                    Console.WriteLine("Name: {0}", queryObj["Name"]);
                    Console.WriteLine("Manufacturer: {0}", queryObj["Manufacturer"]);
                    Console.WriteLine("L2CacheSize: {0}", queryObj["L2CacheSize"]);
                    Console.WriteLine("L3CacheSize: {0}", queryObj["L3CacheSize"]);
                    Console.WriteLine("Description: {0}", queryObj["Description"]);
                }
            }
            catch (ManagementException e)
            {
                Debug.WriteLine("An error occurred while querying for WMI data: " + e.Message);
            }
        }
    }
}
