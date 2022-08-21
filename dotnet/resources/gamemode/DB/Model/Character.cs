using System;
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
        
        public JsonObject clothes { get; set; }
        public JsonObject face { get; set; }
        
        /*
        //Clothes
        public int head { get; set; }
        public int mask { get; set; }
        public int hair { get; set; }
        public int torso { get; set; }
        public int legs { get; set; }
        public int bag { get; set; }
        public int accessories { get; set; }
        public int undershirts { get; set; }
        public int armors { get; set; }
        public int tatto { get; set; }
        public int top { get; set; }
        
        //Face
        public int noseWidth { get; set; }
        public int noseHeight { get; set; }
        public int noseLength { get; set; }
        public int noseBridge { get; set; }
        public int noseTip { get; set; }
        public int noseBridgeShift { get; set; }
        public int browHeight { get; set; }
        public int browWidth { get; set; }
        public int cheekboneHeight { get; set; }
        public int cheekboneWidth { get; set; }
        public int cheeksWidth { get; set; }
        public int eyes { get; set; }
        public int lips { get; set; }
        public int jawWidth { get; set; }
        public int jawHeight { get; set; }
        public int chinLength { get; set; }
        public int chinPosition { get; set; }
        public int chinWidth { get; set; }
        public int chinShape { get; set; }
        public int neckWidth { get; set; }
        */
        
        public virtual User User { get; set; }
        public virtual ICollection<Car> Cars { get; set; }
        public virtual ICollection<Apartament> Apartaments { get; set; }
        public virtual ICollection<Item> Items { get; set; }
    }
}