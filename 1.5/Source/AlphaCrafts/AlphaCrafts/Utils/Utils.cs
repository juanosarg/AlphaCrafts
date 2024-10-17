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


        public static int GetGraphicNumberOffsetForYogurt(Thing thing)
        {
            CompIngredients compIngredients = thing.TryGetComp<CompIngredients>();
            if (compIngredients != null)
            {
                foreach (ThingDef ingredient in compIngredients.ingredients)
                {
                    if (StaticCollections.yogurtOffsets.ContainsKey(ingredient))
                    {
                        return StaticCollections.yogurtOffsets[ingredient];
                    }
                }

            }
            return 0;
        }

        public static int GetGraphicNumberOffsetForOil(Thing thing)
        {
            CompIngredients compIngredients = thing.TryGetComp<CompIngredients>();
            if (compIngredients != null)
            {
                foreach (ThingDef ingredient in compIngredients.ingredients)
                {
                    if (StaticCollections.oilOffsets.ContainsKey(ingredient))
                    {
                        return StaticCollections.oilOffsets[ingredient];
                    }
                }

            }
            return 0;
        }

    }
}


