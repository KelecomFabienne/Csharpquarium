using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpquarium_class.FishSpecies
{
    class Sole : Fishes
    {
        public Sole(string name, FishSex sex, ushort age) : base(name, sex, age, Species.Sole,Food.Herbivore){}
    }
}
