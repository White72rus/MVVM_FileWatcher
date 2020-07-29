using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SkyCloudStorage.SetupApp {
    internal static class Setup
    {
        private static readonly string _path = "settings";
        private static readonly string _pathStorage = "\\AppData\\Roaming\\SCS\\Storage";
        public static Settings GetSettings()
        {
            try
            {
                Settings result;
                if (!new FileInfo(_path).Exists)
                    return new Settings()
                    {
                        PathLocalFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + _pathStorage,
                        AutoRun = true,
                        DataBaseAdrr = "",
                        RememberedUser = "",
                    };

                using (StreamReader sr = File.OpenText(_path))
                {
                    string s = sr.ReadToEnd();
                    return JsonConvert.DeserializeObject<Settings>(s);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }
        }

        public static void SetSettings(Settings settings)
        {
            try
            {
                if (!new FileInfo(_path).Exists)
                {
                    using (StreamWriter sw = File.CreateText(_path))
                    {
                        sw.WriteLine(JsonConvert.SerializeObject(settings));
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }
        }
    }
}
