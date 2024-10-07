using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Verse;
using RimWorld;

namespace AlphaCrafts
{
    public static class Utils
    {

        public static Dictionary<string, int> fruitDefNames = new Dictionary<string, int>() { { "RawBerries", 1 },{ "VCE_RawApple",1 },
        { "VCE_RawPeach",3 },{ "VCE_RawCherry",1 },{ "VCE_RawPlum",4 },{ "VCE_RawPrunes",4 },{ "VCE_RawPear",5 },{ "VCE_RawPricklyPear",1 }
            ,{ "VCE_Bearberry",1 },{ "VCE_RawBanana",2 },{ "VCE_RawOrange",3 },{ "VCE_RawLemon",2 }
            ,{ "VCE_RawAvocado",5 },{ "VCE_RawMelon",5 },{ "VCE_RawPineapple",2 },{ "VCE_Mangoes",3 }

        };

        public static int GetGraphicNumberOffsetForFruit(Thing thing)
        {
            CompIngredients compIngredients = thing.TryGetComp<CompIngredients>();
            if (compIngredients != null)
            {
                foreach (ThingDef ingredient in compIngredients.ingredients)
                {
                    if (fruitDefNames.ContainsKey(ingredient.defName))
                    {

                        return fruitDefNames[ingredient.defName];
                    }


                }



            }


            return 0;
        }

    }
}


