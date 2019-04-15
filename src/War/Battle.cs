using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using War.Model;
using War.Extensions;
using War.Model.ModelExtensions;

namespace War
{
    public class Battle : IBattle
    {
        private Army _army;
        public Battle(Army army)
        {
            _army = army;
        }
        public Army LetsBattle(Army enemyArmy)
        {
            Army army = _army;
            AttackBatallion(enemyArmy.HorseBatallion, army.HorseBatallion);
            AttackBatallion(enemyArmy.ElephantBatallion, army.ElephantBatallion);
            AttackBatallion(enemyArmy.ArmouredTanksBatallion, army.ArmouredTanksBatallion);
            AttackBatallion(enemyArmy.SlingGunsBatallion, army.SlingGunsBatallion);


            ResolveAdditionalResourcesNeeded(army.HorseBatallion, army);
            ResolveAdditionalResourcesNeeded(army.ElephantBatallion, army);
            ResolveAdditionalResourcesNeeded(army.ArmouredTanksBatallion, army);
            ResolveAdditionalResourcesNeeded(army.SlingGunsBatallion, army);

            army.WarWon = army.IsWarWon();
            return army;
        }

        private void AttackBatallion(Batallion enemyBatallion, Batallion myBatallion)
        {
            int extraUnits = enemyBatallion.Units - (myBatallion.Units * _army.ArmyPower);

            if (extraUnits < 0)
            {
                myBatallion.RemainingUnits = (-(extraUnits).RoundNumbertotheRight()) / 2;
            }
            else
            {

                myBatallion.AdditionalNeededResources = (extraUnits.RoundNumbertotheRight()) / 2;
            }

            myBatallion.UsedUnits = myBatallion.Units - myBatallion.RemainingUnits;
        }

        private void ResolveAdditionalResourcesNeeded(Batallion myBatallion, Army myArmy)
        {

            if (myBatallion.AdditionalNeededResources == 0)
            {
                return;
            }

            ResolveAdditionalResourcesWithWithAjacentBatallions(myArmy, myBatallion, myBatallion.Rank - 1);

            if (myBatallion.AdditionalNeededResources == 0)
            {
                return;
            }

            ResolveAdditionalResourcesWithWithAjacentBatallions(myArmy, myBatallion, myBatallion.Rank + 1);

            myBatallion.UsedUnits = myBatallion.Units - myBatallion.RemainingUnits;
        }


        private void ResolveAdditionalResourcesWithWithAjacentBatallions(Army myArmy, Batallion myBatallion, int adjacentBatallionRank)
        {

            var adjacentRankedBatallion = myArmy.GetBatallionByRank(adjacentBatallionRank);
            if (adjacentRankedBatallion != null && adjacentRankedBatallion.RemainingUnits > 0)
            {
                int availableWeightedUnitsFromAdjacentBatallion = adjacentRankedBatallion.ReturnWeightage(myBatallion.Rank, adjacentRankedBatallion.RemainingUnits);
                int neededEquivalentUnits = availableWeightedUnitsFromAdjacentBatallion - myBatallion.AdditionalNeededResources;

                if (neededEquivalentUnits > 0)
                {
                    adjacentRankedBatallion.RemainingUnits -= myBatallion.ReturnWeightage(adjacentBatallionRank, myBatallion.AdditionalNeededResources);
                    myBatallion.AdditionalNeededResources = 0;
                }
                else
                {
                    myBatallion.AdditionalNeededResources -= availableWeightedUnitsFromAdjacentBatallion;
                    adjacentRankedBatallion.RemainingUnits = 0;
                }
                adjacentRankedBatallion.UsedUnits += (adjacentRankedBatallion.Units - (adjacentRankedBatallion.UsedUnits + adjacentRankedBatallion.RemainingUnits));
            }
        }
    }
}
