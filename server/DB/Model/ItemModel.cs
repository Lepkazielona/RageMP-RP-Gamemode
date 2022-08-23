using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks.Dataflow;

namespace DB

{
    public class ItemModel
    {
        public int ID { get; set; }
        public string name { get; set; }
        public string texture { get; set; }

        public bool isEatable { get; set; }

        //public JsonObject
        //public JsonObject<string[]> param { get; set; }

    public virtual ICollection<Item> items { get; set; }
    }
}