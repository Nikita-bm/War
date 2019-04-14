using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using War.Extensions;
using War.Model.ModelExtensions;

namespace War.Model
{
    public class Army
    {
        public Army()
        {

        }
        public Army(int slingGunCapacity, int armouredTankCapacity, int elephantCapacity, int horseCapacity)
        {
            HorseBatallion = new Batallion(1, horseCapacity);
            ElephantBatallion = new Batallion(2, elephantCapacity);
            ArmouredTanksBatallion = new Batallion(3, armouredTankCapacity);
            SlingGunsBatallion = new Batallion(4, slingGunCapacity);
        }

        public Batallion HorseBatallion { get; set; }
        public Batallion ElephantBatallion { get; set; }

        public Batallion ArmouredTanksBatallion { get; set; }

        public Batallion SlingGunsBatallion { get; set; }


        public int ArmyPower { get { return 2; } }

        public string WarWon { get; set; }


        public Army Attack(Army enemyArmy)
        {
            Army army = this;
            DoAttack(enemyArmy.HorseBatallion, army.HorseBatallion);
            DoAttack(enemyArmy.ElephantBatallion, army.ElephantBatallion);
            DoAttack(enemyArmy.ArmouredTanksBatallion, army.ArmouredTanksBatallion);
            DoAttack(enemyArmy.SlingGunsBatallion, army.SlingGunsBatallion);


            ResolveAdditionalResourcesNeeded(army.HorseBatallion, army);
            ResolveAdditionalResourcesNeeded(army.ElephantBatallion, army);
            ResolveAdditionalResourcesNeeded(army.ArmouredTanksBatallion, army);
            ResolveAdditionalResourcesNeeded(army.SlingGunsBatallion, army);

            army.WarWon = army.IsWarWon();
            return army;
        }

        private void DoAttack(Batallion enemyBatallion, Batallion myBatallion)
        {
            int extraUnits = enemyBatallion.Units - (myBatallion.Units * ArmyPower);

            if (extraUnits < 0)
            {
                myBatallion.RemainingUnits = (-(extraUnits).RoundNumbertotheRight()) / 2;
            }
            else
            {

                myBatallion.AdditionalNeededResources = (extraUnits.RoundNumbertotheRight()) / 2;
            }
        }

        private void ResolveAdditionalResourcesNeeded(Batallion myBatallion, Army myArmy)
        {

            if (myBatallion.AdditionalNeededResources == 0)
            {
                myBatallion.UsedUnits = myBatallion.Units - myBatallion.RemainingUnits;
                return;
            }

            var lowerRankedBatallion = myArmy.GetBatallionByRank(myBatallion.Rank - 1);
            if (lowerRankedBatallion != null && lowerRankedBatallion.RemainingUnits > 0)
            {

                int equivalentUnits = lowerRankedBatallion.ReturnWeightage(myBatallion.Rank, lowerRankedBatallion.RemainingUnits);
                if (equivalentUnits > myBatallion.AdditionalNeededResources)
                {
                    myBatallion.AdditionalNeededResources = 0;
                    lowerRankedBatallion.RemainingUnits -= equivalentUnits;
                }
                else
                {
                    myBatallion.AdditionalNeededResources -= equivalentUnits;
                    lowerRankedBatallion.RemainingUnits = 0;
                }
                lowerRankedBatallion.UsedUnits = lowerRankedBatallion.UsedUnits + myBatallion.ReturnWeightage(lowerRankedBatallion.Rank, equivalentUnits);


            }
            if (myBatallion.AdditionalNeededResources == 0)
                return;
            var higherRankedBatallion = myArmy.GetBatallionByRank(myBatallion.Rank + 1);
            if (higherRankedBatallion != null && higherRankedBatallion.RemainingUnits > 0)
            {
                int equivalentUnits = higherRankedBatallion.ReturnWeightage(myBatallion.Rank, higherRankedBatallion.RemainingUnits);

                if (equivalentUnits > myBatallion.AdditionalNeededResources)
                {
                    myBatallion.AdditionalNeededResources = 0;
                    higherRankedBatallion.RemainingUnits -= equivalentUnits;
                }
                else
                {
                    myBatallion.AdditionalNeededResources -= equivalentUnits;
                    higherRankedBatallion.RemainingUnits = 0;
                }
                higherRankedBatallion.UsedUnits = higherRankedBatallion.UsedUnits + myBatallion.ReturnWeightage(higherRankedBatallion.Rank, equivalentUnits);
            }

            myBatallion.UsedUnits = myBatallion.Units - myBatallion.RemainingUnits;
        }
    }
}
