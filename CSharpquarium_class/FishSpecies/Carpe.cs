using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpquarium_class.FishSpecies
{
    class Carpe : Fishes
    {
        public Carpe(string name,  FishSex sex, ushort age) : base(name, sex, age, Species.Carpe, Food.Herbivore){}
        
    }
}
