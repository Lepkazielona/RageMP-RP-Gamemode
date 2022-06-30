namespace DB

{
    public class Car
    {
        public int ID { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public int z { get; set; }
        public int milage { get; set; }
        public virtual CarModel CarModel { get; set; }
        public virtual Character Characters { get; set; }
    }
}