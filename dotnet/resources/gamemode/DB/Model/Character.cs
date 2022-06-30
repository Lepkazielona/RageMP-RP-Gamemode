using System.Collections;
using System.Collections.Generic;

namespace DB

{
    public class Character
    {
        public int ID { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public int money { get; set; }
        public int age { get; set; }
        
        public virtual User User { get; set; }
        public virtual ICollection<Car> Cars { get; set; }
        public virtual ICollection<Apartament> Apartaments { get; set; }
        public virtual ICollection<Item> Items { get; set; }
    }
}