using System;
using System.Collections.Generic;
using System.Text;

namespace STSys.Core.File.Abstractions.Entities
{
    public class ImagesEntity
    {
        public string Id { get; set; }
        public string Address { get; set; }
        public DateTime CreateTime { get; set; }
        public string WebfileUrl { get; set; }
    }
}
