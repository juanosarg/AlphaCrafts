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

        public static int GetGraphicNumberOffsetForPerfume(Thing thing)
        {
            CompIngredients compIngredients = thing.TryGetComp<CompIngredients>();
            if (compIngredients != null)
            {
                foreach (ThingDef ingredient in compIngredients.ingredients)
                {
                    if (StaticCollections.perfumeOffsets.ContainsKey(ingredient))
                    {
                        return StaticCollections.perfumeOffsets[ingredient];
                    }
                }

            }
            return 0;
        }

        public static int GetGraphicNumberOffsetForButter(Thing thing)
        {
            CompIngredients compIngredients = thing.TryGetComp<CompIngredients>();
            if (compIngredients != null)
            {
                foreach (ThingDef ingredient in compIngredients.ingredients)
                {
                    if (StaticCollections.butterOffsets.ContainsKey(ingredient))
                    {
                        return StaticCollections.butterOffsets[ingredient];
                    }
                }

            }
            return 0;
        }
        public static int GetGraphicNumberOffsetForVinegar(Thing thing)
        {
            CompIngredients compIngredients = thing.TryGetComp<CompIngredients>();
            if (compIngredients != null)
            {
                foreach (ThingDef ingredient in compIngredients.ingredients)
                {
                    if (StaticCollections.vinegarOffsets.ContainsKey(ingredient))
                    {
                        return StaticCollections.vinegarOffsets[ingredient];
                    }
                }

            }
            return 0;
        }

        public static int GetGraphicNumberOffsetForFlour(Thing thing)
        {
            CompIngredients compIngredients = thing.TryGetComp<CompIngredients>();
            if (compIngredients != null)
            {
                foreach (ThingDef ingredient in compIngredients.ingredients)
                {
                    if (StaticCollections.flourOffsets.ContainsKey(ingredient))
                    {
                        return StaticCollections.flourOffsets[ingredient];
                    }
                }

            }
            return 0;
        }

        public static int GetGraphicNumberOffsetForChips(Thing thing)
        {
            CompIngredients compIngredients = thing.TryGetComp<CompIngredients>();
            if (compIngredients != null)
            {
                foreach (ThingDef ingredient in compIngredients.ingredients)
                {
                    if (StaticCollections.chipsOffsets.ContainsKey(ingredient))
                    {
                        return StaticCollections.chipsOffsets[ingredient];
                    }
                }

            }
            return 0;
        }
        public static int GetGraphicNumberOffsetForZest(Thing thing)
        {
            CompIngredients compIngredients = thing.TryGetComp<CompIngredients>();
            if (compIngredients != null)
            {
                foreach (ThingDef ingredient in compIngredients.ingredients)
                {
                    if (StaticCollections.zestOffsets.ContainsKey(ingredient))
                    {
                        return StaticCollections.zestOffsets[ingredient];
                    }
                }

            }
            return 0;
        }

        public static int GetGraphicNumberOffsetForPuree(Thing thing)
        {
            CompIngredients compIngredients = thing.TryGetComp<CompIngredients>();
            if (compIngredients != null)
            {
                foreach (ThingDef ingredient in compIngredients.ingredients)
                {
                    if (StaticCollections.pureeOffsets.ContainsKey(ingredient))
                    {
                        return StaticCollections.pureeOffsets[ingredient];
                    }
                }

            }
            return 0;
        }
    }
}


