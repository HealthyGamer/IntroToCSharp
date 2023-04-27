using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    internal class Plant
    {
        public int Energy { get; set; }
        public int Water { get; set; }
        public int GrowthStage { get; set; }

        public Plant() { 
            Energy = 5;
            Water = 5;
            GrowthStage = 0;
        }

        public void UpdateStats(int water, int energy, int growth = 0)
        {
            Water += water;
            Energy += energy;
            GrowthStage += growth;
        }

        public bool IsAlive()
        {
            return Water > 0 && Energy > 0;
        }
    }
}
