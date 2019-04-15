namespace War.Model.ModelExtensions
{
    public static class ModelExtensions
    {
        public static Batallion GetBatallionByRank(this Army myArmy , int rank)
        {
            switch (rank)
            {
                case 1:
                    return myArmy.HorseBatallion;
                case 2:
                    return myArmy.ElephantBatallion;
                case 3:
                    return myArmy.ArmouredTanksBatallion;
                case 4:
                    return myArmy.SlingGunsBatallion;
                default:
                    return default(Batallion);
            }
        }

        public static string IsWarWon(this Army army)
        {
            if(army.HorseBatallion.AdditionalResourcesNeeded() && army.ElephantBatallion.AdditionalResourcesNeeded() && army.ArmouredTanksBatallion.AdditionalResourcesNeeded() && army.SlingGunsBatallion.AdditionalResourcesNeeded())
            {
                return "has Won";
            }
            return "has Lost";
        }

        public static bool AdditionalResourcesNeeded(this Batallion batallion)
        {
            if(batallion.AdditionalNeededResources == 0 )
            {
                return true;
            }
            return false;
        }

    }
}
