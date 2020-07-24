using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SkyCloudStorage.SetupApp {
    class Settings {

        [JsonProperty(PropertyName = "pathLocalFolder")]
        public string PathLocalFolder { get; set; }

        [JsonProperty(PropertyName = "dataBaseAdrr")]
        public string DataBaseAdrr { get; set; }

        [JsonProperty(PropertyName = "autoRun")]
        public bool AutoRun { get; set; }

        [JsonProperty(PropertyName = "rememberedUser")]
        public string RememberedUser { get; set; }
    }
}
