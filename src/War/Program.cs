using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace War
{
    class Program
    {
        static void Main(string[] args)
        {
            //Available resources => 100 H , 50 E, 10T, 5 G

            //input 
            //toReplaceH = (input H/2) 
            //extraNeeded = availableR - toreplace
            //if9extra needed -> use adjacent 

            Dictionary<string, int> inputBattalionsFalicornia = new Dictionary<string, int>();
            inputBattalionsFalicornia.Add("Guns", 8);
            inputBattalionsFalicornia.Add("ArmouredTanks", 26);
            inputBattalionsFalicornia.Add("Elephants", 96);
            inputBattalionsFalicornia.Add("Horses", 150);
          
         
           
            Dictionary<string, int> availableBattalionsLengabiru = new Dictionary<string, int>();
            availableBattalionsLengabiru.Add("Guns", 5);
            availableBattalionsLengabiru.Add("ArmouredTanks", 10);
            availableBattalionsLengabiru.Add("Elephants", 50);
            availableBattalionsLengabiru.Add("Horses", 100);


            Dictionary<string, int> remainingBattalionsLengabiru = new Dictionary<string, int>();


            int index = 0;
            Dictionary<string, int> output = new Dictionary<string, int>();

            foreach (var battalionFalicornia in inputBattalionsFalicornia.ToList())
            {

                index += 1;
                int inputBattalion = inputBattalionsFalicornia.GetValueForKey(battalionFalicornia.Key);
                int neededEquivalentLengabiruBatallion= inputBattalion % 2 == 0 ?   inputBattalion / 2 : (inputBattalion/2) + 1;
                int extraNeededLengabiruBatallion = neededEquivalentLengabiruBatallion - availableBattalionsLengabiru.GetValueForKey(battalionFalicornia.Key);

                if (extraNeededLengabiruBatallion > 0)
                {
                    KeyValuePair<string, int> nextSmallerBattalion = inputBattalionsFalicornia.ElementAt(index);
                    output.Add(battalionFalicornia.Key, neededEquivalentLengabiruBatallion - extraNeededLengabiruBatallion);
                    if ((inputBattalionsFalicornia.GetValueForKey(test.Key)/2) > availableBattalionsLengabiru.GetValueForKey(test.Key))
                    {
                        output[remainingBattalionsLengabiru.ElementAt(index - 2).Key] = existing value  + remainingBattalionsLengabiru.GetValueForKey(test.Key)
                    }
                    else
                    {
                        inputBattalionsFalicornia[test.Key] = inputBattalionsFalicornia.GetValueForKey(nextSmallerBattalion.Key) + (extraNeededLengabiruBatallion *2);
                    }
                  
                }
                else
                {
                    remainingBattalionsLengabiru.Add(battalionFalicornia.Key, availableBattalionsLengabiru.GetValueForKey(battalionFalicornia.Key) - neededEquivalentLengabiruBatallion);
                    output.Add(battalionFalicornia.Key, neededEquivalentLengabiruBatallion);
                }
               
            }
            






        }

       

    }



    public static class ExtensionMethod
    {
        public  static int GetValueForKey(this Dictionary<string, int> dictionary, string key)
        {
            int value;
            dictionary.TryGetValue(key, out value);

            return value;
        }
    }
   

    //Classes -> Base class -> Weapon (Rank) ,
    //Battalion -> List horses (Predecessor and Succssor), Elephants 
    //Army -> List of battalion 

    //

}
