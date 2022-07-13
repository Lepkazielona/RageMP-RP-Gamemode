namespace DB

{
    public class Car
    {
        public int ID { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public int z { get; set; }
        public float rot { get; set; }
        public int color1 { get; set; }
        public int color2 { get; set; }
        public int mileage { get; set; }
        public string plate { get; set; }
        public virtual CarModel CarModel { get; set; }
        public virtual Character Owner { get; set; }
    }
}