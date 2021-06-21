using System;
using System.Collections.Generic;
using CSharpquarium_class.FishSpecies;
using CSharpquarium_class;

namespace CSharpquarium_class
{
    public class Aquarium
    {
        public List<Fishes> listingfish;
        public List<Seaweed> listingSeaweed;
        private ushort _aquariumAge = 0;
        public ushort eatedAlguecmp;
        public ushort eatedfishcmp;
        public Aquarium()
        {
            listingfish = new List<Fishes>();
            listingSeaweed = new List<Seaweed>();
            AddTurnEvent = null;
            AddTurnEvent += GetOlderAll;
            AddTurnEvent += Eating;
        }
        public ushort AquariumAge { get => _aquariumAge; }
        public event Action <Aquarium>AddTurnEvent;
        #region Méthodes
        #region Méthodes privées
        private void Eating( Aquarium aquarium) 
        {
            eatedAlguecmp = 0;
            eatedfishcmp = 0;
            foreach (Fishes fish in aquarium.listingfish)
            {
                if (fish.IsHungry(this))
                {
                    if (fish.Alimentation == Food.Carnivore) {fish.SeNourir(aquarium.listingfish,4,5);
                        eatedfishcmp++;
                    }
                    else if(listingSeaweed.Count !=0) {fish.SeNourir(aquarium.listingSeaweed, 2, 3);
                        eatedAlguecmp++;
                    }
                }
            }
        }
        private void GetOlderAll(Aquarium aquarium) 
        {
            for (int i = listingfish.Count-1; i >= 0; i--)
            {
                listingfish[i].GetOlder(aquarium.listingfish, listingfish[i]);
            }
            //if (listingfish.Count !=0)
            //{
            //    foreach (Fishes fish in aquarium.listingfish)
            //{
            //    fish.GetOlder(aquarium.listingfish, fish);
            //}

            //}
            if (listingSeaweed.Count != 0) 
            {
                for (int i = listingSeaweed.Count-1; i >= 0; i--)
                {
                    listingSeaweed[i].GetOlder(aquarium.listingSeaweed, listingSeaweed[i]);
                }
            
            }
        }
        
        #endregion
        #region Méthodes publiques
        public void AddFish(string name, FishSex sex, ushort age, Species espece)
        {
            switch (espece)
            {
                case Species.Merou:
                    listingfish.Add(new Merou(name, sex, age));
                    break;
                case Species.Bar:
                    listingfish.Add(new Bar(name, sex, age));
                    break;
                case Species.Carpe:
                    listingfish.Add(new Carpe(name, sex, age));
                    break;
                case Species.Poisson_clown:
                    listingfish.Add(new Poisson_clown(name, sex, age));
                    break;
                case Species.Sole:
                    listingfish.Add(new Sole(name, sex, age));
                    break;
                case Species.Thon:
                    listingfish.Add(new Thon(name, sex, age));
                    break;
            }
        }
        public void AddSeaweed() => listingSeaweed.Add(new Seaweed());
        public void AddTurn() 
        { 
            _aquariumAge +=(ushort) 1;
            AddTurnEvent?.Invoke(this);
        }
        
        #endregion
        #endregion
    }
}
