using System;
using System.Collections.Generic;
using System.Text;
using CSharpquarium_class;
using CSharpquarium_program;

namespace CSharpquarium_program.Models
{
    public static class MethodeConsole
    {
        
        public static void AddturnAction(Aquarium aquarium) 
        {
            Console.WriteLine($"Votre aquarium a {aquarium.AquariumAge} tour(s). Il possède {aquarium.listingfish.Count} poissons et {aquarium.listingSeaweed.Count} algues.");
        }
        public static void EatedlivingAction(Aquarium aquarium) {
            if (aquarium.eatedfishcmp == 0) { Console.WriteLine("Aucun poisson attaqué ! Lucky you !"); }
            else { Console.WriteLine($"Oh ... {aquarium.eatedfishcmp} poisson(s) ont été attaqué(s) ... Les poissons ont peur ..."); }
            if (aquarium.eatedAlguecmp == 0)
            {
                Console.WriteLine("Les algues sont en paix. Aucune d'entre elles n'a été grignottée...");
            }
            else {Console.WriteLine($"Oh ! {aquarium.eatedAlguecmp} algue(s) ont été mangée(s)... Les algues reste coient devant tant de barbarie..."); }
             }
    }
}
