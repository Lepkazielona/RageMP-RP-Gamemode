using System.Collections;
using System.Collections.Generic;

namespace DB

{
    public class CarModel
    {
        public int ID { get; set; }
        public string name { get; set; }
        public string model { get; set; }
        public virtual ICollection<Car> Cars { get; set; }
    }
    
}