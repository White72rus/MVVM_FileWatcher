using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyCloudStorage.Model {
    internal interface IPasswordSupplier
    {
        string GetPassword();
    }
}
