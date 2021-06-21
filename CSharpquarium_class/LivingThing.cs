using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpquarium_class
{
    public class LivingThing

    {
        public ushort pv = 10;
        private ushort _age;

        public ushort Age
        {
            get { return _age; }
            set { _age = value;}
        }

        public static void IsDead<T>(List<T> list, T living) where T : LivingThing
        {
            list.Remove(living);
        }
        public virtual void GetOlder<T>(List<T> list, T living) where T : LivingThing
        {
            living.Age += 1;
            if (living.Age>20)
            {
                IsDead(list, living);
            }
        }
        
    }
}
