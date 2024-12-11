using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EggfarmModel.Model
{
    public class Chicken : Poultry
    {
        public Chicken() : base("New Chicken")
        {
            this.Weight = 1000;
        }

        public Chicken(string name) : this()
        {
            this.Name = name;
        }

        public string Stable { get; set; }

        public override void Eat()
        {
            if (this.Weight < 3000)
            {
                this.Weight += 100;
            }
        }

        public override void LayEgg()
        {
            if (this.Weight > 1500)
            {
                Egg egg = new Egg(this);
                this.Eggs.Add(egg);
                this.Weight -= egg.Weight;
            }
        }
    }
}
