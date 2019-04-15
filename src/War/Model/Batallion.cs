using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace War.Model
{
    public class Batallion
    {
        public Batallion(int rank, int units)
        {
            Rank = rank;
            Units = units;
        }

        public int Rank { get; set; }
        public int Units { get; set; }

        public int RemainingUnits { get; set; }

        public int UsedUnits { get; set; }
        public int AdditionalNeededResources { get; set; }

        public int ReturnWeightage(int rank, int value)
        {
            if (this.Rank < rank)
            {
                return value / 2;
            }
            return value * 2;
        }
    }
}
