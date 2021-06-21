using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpquarium_class.FishSpecies
{
    class Bar : Fishes
    {
        public Bar(string name, FishSex sex, ushort age) : base(name, sex, age, Species.Bar, Food.Herbivore) {}
        
    }
}
