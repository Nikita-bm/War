using War.Extensions;
using War.Model.ModelExtensions;

namespace War.Model
{
    public class Army
    {
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
    }
}
