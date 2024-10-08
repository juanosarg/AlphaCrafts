
using Verse;
using System;
using RimWorld;
using System.Collections.Generic;
using System.Linq;


namespace AlphaCrafts
{
    [StaticConstructorOnStartup]
    public static class StaticCollections
    {

       public static Dictionary<ThingDef,int> fruitOffsets = new Dictionary<ThingDef, int>();

        static StaticCollections()
        {
            List<FruitOffsets> allFruitLists = DefDatabase<FruitOffsets>.AllDefsListForReading.ToList();
            foreach (FruitOffsets individualList in allFruitLists)
            {    
              
                fruitOffsets.AddRange(individualList.fruitAndOffsetList);                                          
            }
        }




    }
}
