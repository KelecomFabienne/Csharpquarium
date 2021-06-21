using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpquarium_class
{
    public class Merou : Fishes
    {
        
        public Merou(string name, FishSex sex, ushort age) : base(name, sex, age, Species.Merou, Food.Carnivore){}
        
    }
}
