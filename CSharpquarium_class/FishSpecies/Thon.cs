using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpquarium_class.FishSpecies
{
    class Thon : Fishes
    {
        public Thon(string name, FishSex sex, ushort age) : base(name, sex, age, Species.Thon, Food.Carnivore){}
        
    }
}
