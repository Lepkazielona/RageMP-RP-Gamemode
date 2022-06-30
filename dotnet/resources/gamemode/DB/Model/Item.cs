namespace DB

{
    public class Item
    {
        public int ID { get; set; }
        public int count { get; set; }
        public string customName { get; set; }
        
        public virtual ItemModel ItemModel { get; set; }
        public virtual Character Character { get; set; }
    }
}