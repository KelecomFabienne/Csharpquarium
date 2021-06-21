using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpquarium_class.FishSpecies
{
    class Poisson_clown : Fishes
    {
        public Poisson_clown(string name, FishSex sex, ushort age) : base(name, sex, age, Species.Poisson_clown, Food.Carnivore){}
        
    }
}
