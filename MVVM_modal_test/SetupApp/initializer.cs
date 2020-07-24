using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Principal;
using System.Diagnostics;

namespace SkyCloudStorage.SetupApp {
    internal class Initializer {
        public static Initializer Instance { get; } = new Initializer();

        private Settings _settings;

        private Initializer()
        {
            _settings = Setup.GetSettings();

            DirectoryInfo directory = new DirectoryInfo(_settings.PathLocalFolder);

            if (!directory.Exists)
            {
                try
                {
                    directory.Create();
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e);
                    throw;
                }
            }
            return;
        }
    }
}
