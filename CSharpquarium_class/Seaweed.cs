using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpquarium_class
{
    public class Seaweed : LivingThing
    {
        public void Grow(Aquarium aquarium) 
        {
            pv++;
            GetOlder(aquarium.listingSeaweed, this);
        }

    }
}
