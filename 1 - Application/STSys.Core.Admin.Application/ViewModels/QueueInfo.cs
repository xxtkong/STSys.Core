using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace STSys.Core.Admin.Application.ViewModels
{
    public class QueueInfo
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId id { get; set; }

        [BsonElement(nameof(level))]//指明数据库中字段名为level
        public string level { get; set; }
        public string name { get; set; }
        public string msg { get; set; }
    }
}
