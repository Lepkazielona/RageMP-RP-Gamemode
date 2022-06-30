using System;
using System.Collections;
using System.Collections.Generic;

namespace DB

{
    public class User
    {
        public int ID { get; set; }
        public string nickname { get; set; }
        public string password { get; set; }
        public string passwordSol { get; set; }
        public DateTime creationDate { get; set; }
        public int rank { get; set; }
        public long gameTime { get; set; }
        public virtual ICollection<Character> Characters { get; set; }
    }
}