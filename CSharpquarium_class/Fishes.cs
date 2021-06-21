using System;
using System.Collections.Generic;
using System.Text;
using CSharpquarium_class;

namespace CSharpquarium_class
{
    public abstract class Fishes : LivingThing
    {
        private string _name;
        private bool _sex;

        #region Propriétés
        public string Name
        {
            get { return _name; }
            private set
            {
                if (!(value is string)) throw new InvalidCastException();
                if (value is null) throw new ArgumentNullException();
                _name = value;
            }
        }
        public FishSex Sex
        {
            get { return (_sex == true) ? FishSex.Male : FishSex.Femelle; }
            set { _sex = (value == FishSex.Male) ? true : false; }
        }
        public Species Species { get; private set; }
        public Food Alimentation { get; private set; }

        #endregion

        public Fishes(string name, FishSex sex, ushort age, Species species, Food alimentation )// espèce à la place de foodlife
        {
            Name = name;
            Sex = sex;
            Species = species;
            Alimentation = alimentation;
            Age = age;
            
        }
        #region Méthodes
        #region Test Méthodes SeNourir
        //private void SeNourirCarn(List<Fishes> fishes)
        //{
        //    Random rdm = new Random();
        //    int index = rdm.Next(0, (fishes.Count) - 1);
        //    Fishes eatedfish = fishes[index];
        //    if (!(eatedfish == this))
        //    {
        //        eatedfish.pv -= 4;
        //        if (eatedfish.pv <= 0)
        //        {
        //            IsDead<Fishes>(fishes, eatedfish);
        //        }
        //        this.pv += 5;
        //    }
        //}

        //private void SeNourirVeg(List<Seaweed> weeds)
        //{
        //    Random rdm = new Random();
        //    int index = rdm.Next(0, (weeds.Count) - 1);
        //    Seaweed eatedweed = weeds[index];
        //    eatedweed.pv -= 0;
        //    if (eatedweed.pv <= 0)
        //    {
        //        IsDead<Seaweed>(weeds, eatedweed);
        //    }
        //    this.pv += 3;
        //} 
        #endregion
        #region Méthodes publiques
        public bool IsHungry(Aquarium aquarium)
        {
            this.pv -= 1;
            if (this.pv == 0)
            {
                IsDead<Fishes>(aquarium.listingfish, this);
            }
            else if (this.pv <= 5)
            {
                return true;
            }
            return false;
        }

        public void SeNourir<T>(List<T> list, ushort hit, ushort gain) where T : LivingThing
        {
            Random rdm = new Random();
            int index = rdm.Next(0, (list.Count) - 1);
            T eatedliving = list[index];
            bool condition = true;
            switch (eatedliving)
            {
                case Fishes fsh:
                    if (fsh.Species == this.Species)
                    {
                        condition = false;
                    }
                    break;
            }
            if (condition)
            {
                eatedliving.pv -= hit;
                if (eatedliving.pv <= 0)
                {
                    IsDead<T>(list, eatedliving);
                }
                this.pv += gain;
            }
        }

        public override void GetOlder<Fishes>(List<Fishes> list, Fishes living)
        {
            base.GetOlder(list, living);
            //changement de sexe des poissons
        }
        
        #endregion
        #endregion

    }
}
