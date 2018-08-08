using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jacaranda.Utilities.Interfaces
{
    public interface ICloudStorage
    {
        Stream GetFileStream(string bucket, string fileName);
    }
}
