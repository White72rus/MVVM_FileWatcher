using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyCloudStorage.Model {
    public class InfoTost {
        public string Name { get; set; }
        public string Desc { get; set; }
        public InfoTost(string name, string desc)
        {
            Name = name;
            Desc = desc;
        }
    }
}
