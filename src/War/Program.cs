using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using War.Model;

namespace War
{
    class Program
    {
        static void Main(string[] args)
        {
            var lengaburuArmy = CreateArmy(5, 10, 50, 100);

            var falicornianArmy = CreateArmy(5, 20, 101, 100);
            var result = lengaburuArmy.Attack(falicornianArmy);
            Console.WriteLine(result.HorseBatallion.Units + "H " + result.ElephantBatallion.Units + "E " + result.ArmouredTanksBatallion.Units + "AT " + result.SlingGunsBatallion.Units + "SG " + result.WarWon);


            var falicornianArmy1 = CreateArmy(8, 26, 96, 150);
            var result1 = lengaburuArmy.Attack(falicornianArmy1);
            Console.WriteLine(result1.HorseBatallion.UsedUnits + "H " + result1.ElephantBatallion.UsedUnits + "E " + result1.ArmouredTanksBatallion.UsedUnits + "AT " + result1.SlingGunsBatallion.UsedUnits + "SG " + result1.WarWon);


            var falicornianArmy2 = CreateArmy(15, 20, 50, 250);
            var result2 = lengaburuArmy.Attack(falicornianArmy2);
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
