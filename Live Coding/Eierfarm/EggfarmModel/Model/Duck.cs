using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EggfarmModel.Model
{
    public class Duck : Poultry
    {
        public Duck() : base("New Duck")
        {
            this.Weight = 750;
        }

        public Duck(string name) : this()
        {
            this.Name = name;
        }

        public int PondNumber { get; set; }

        public override void Eat()
        {
            if (this.Weight < 2500)
            {
                this.Weight += 75;
            }
        }

        public override void LayEgg()
        {
            if (this.Weight > 1000)
            {
                Egg egg = new Egg(this);
                this.Weight -= egg.Weight;
                this.Eggs.Add(egg);
            }
        }
    }
}
