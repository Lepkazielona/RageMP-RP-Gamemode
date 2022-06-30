using System.Collections;
using System.Collections.Generic;

namespace DB

{
    public class ItemModel
    {
      public int ID { get; set; }
      public string name { get; set; }
      public string texture { get; set; }
      public bool IsEatable { get; set; }
      public virtual ICollection<Item> items { get; set; }
    }
}