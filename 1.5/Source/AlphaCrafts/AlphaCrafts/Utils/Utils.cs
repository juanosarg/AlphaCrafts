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

        public static int GetGraphicNumberOffsetForFruit(Thing thing)
        {
            CompIngredients compIngredients = thing.TryGetComp<CompIngredients>();
            if (compIngredients != null)
            {
                foreach (ThingDef ingredient in compIngredients.ingredients)
                {
                    if (StaticCollections.fruitOffsets.ContainsKey(ingredient))
                    {
                        return StaticCollections.fruitOffsets[ingredient];
                    }
                }

            }
            return 0;
        }

    }
}


