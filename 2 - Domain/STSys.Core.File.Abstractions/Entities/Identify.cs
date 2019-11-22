using System;
using System.Collections.Generic;
using System.Text;

namespace STSys.Core.File.Abstractions.Entities
{
    public class Identify
    {
        public string Project { get; set; }
        public string FileName { get; set; }
        public byte[] fs { get; set; }
    }
}
