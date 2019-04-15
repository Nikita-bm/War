using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using War.Model;

namespace War
{
    public class Program
    {
        public  static IBattle _battle;
       
        static void Main(string[] args)
        {
            _battle = new Battle(CreateArmy(5, 10, 50, 100));

            var result = _battle.LetsBattle(CreateArmy(5, 20, 101, 100));

            Console.WriteLine(result.HorseBatallion.UsedUnits + "H " + result.ElephantBatallion.UsedUnits + "E " + result.ArmouredTanksBatallion.UsedUnits + "AT " + result.SlingGunsBatallion.UsedUnits + "SG " + result.WarWon);

            var result1 = _battle.LetsBattle(CreateArmy(8, 26, 96, 150));
            Console.WriteLine(result1.HorseBatallion.UsedUnits + "H " + result1.ElephantBatallion.UsedUnits + "E " + result1.ArmouredTanksBatallion.UsedUnits + "AT " + result1.SlingGunsBatallion.UsedUnits + "SG " + result1.WarWon);

            var result2 = _battle.LetsBattle(CreateArmy(15, 20, 50, 250));
            Console.WriteLine(result2.HorseBatallion.UsedUnits + "H " + result2.ElephantBatallion.UsedUnits + "E " + result2.ArmouredTanksBatallion.UsedUnits + "AT " + result2.SlingGunsBatallion.UsedUnits + "SG " + result2.WarWon);

            Console.ReadKey();

        }

        private static Army CreateArmy(int slingGunCapacity, int armouredTankCapacity, int elephantCapacity, int horseCapacity)
        {
            Army army = new Army(slingGunCapacity, armouredTankCapacity, elephantCapacity, horseCapacity);
            return army;
        }

    }
}
