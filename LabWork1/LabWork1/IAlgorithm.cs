using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabWork1
{
    public interface IAlgorithm
    {
        public string alphabet { get; }
        public string Encode(string message, string key);
        public string Decode(string message, string key);
    }
}
