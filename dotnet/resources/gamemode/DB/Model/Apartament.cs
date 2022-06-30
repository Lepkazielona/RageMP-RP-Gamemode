using System.Collections;
using System.Collections.Generic;

namespace DB
{
    public class Apartament
    {
        public int ID { get; set; }
        public string name { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public int z { get; set; }
        public virtual Character Characters { get; set; }
    }
}