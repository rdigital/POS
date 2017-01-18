﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OpenLayersWebAPI.DataTypes
{
    public class Feature
    {
        public string type { get; set; } = "Feature";
        public int id { get; set; }
        public Dictionary<string, JToken> properties { get; set; }
        public Geometry geometry { get; set; }

        public JObject getJson()
        {
            var obj = new JObject();

            obj.Add("type", type);
            obj.Add("id", id);
            var propertyJObj = new JObject();
            properties.ToList().ForEach(kvp => propertyJObj.Add(kvp.Key, kvp.Value));
            obj.Add("properties", propertyJObj);
            obj.Add("geometry", geometry.getJson());

            return obj;
        }
    }
}
