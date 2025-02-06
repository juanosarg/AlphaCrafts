
using HarmonyLib;
using JetBrains.Annotations;
using RimWorld;
using System.Linq;
using UnityEngine;
using Verse;
using System;

namespace AlphaCrafts
{
    [HarmonyPatch(typeof(GenRecipe), "PostProcessProduct")]
    public class AlphaCrafts_GenRecipe_PostProcessProduct_Patch
    {
        [HarmonyPostfix]
        private static void PostFix(Thing product, RecipeDef recipeDef, ref Thing __result, Pawn worker)
        {
            int resultingStack = __result.stackCount;
            if (recipeDef.GetModExtension<VariableOutputByIngredient>() != null)
            {
                VariableOutputByIngredient extension = recipeDef.GetModExtension<VariableOutputByIngredient>();
                ThingDef baseline = extension.baseline;

                ThingDef baselinePlant = DefDatabase<ThingDef>.AllDefsListForReading.Where(x => x.plant?.harvestedThingDef == baseline).FirstOrFallback(null);

                ThingDef productIngredient = null;
                ThingDef productIngredientPlant = null;

                CompIngredients compIngredients = product.TryGetComp<CompIngredients>();
                if (compIngredients != null)
                {
                    productIngredient = compIngredients.ingredients.Where(x => extension.exclusions?.Contains(x) != true).FirstOrFallback(null);

                    productIngredientPlant = DefDatabase<ThingDef>.AllDefsListForReading.Where(x => x.plant?.harvestedThingDef == productIngredient).FirstOrFallback(null);


                    float basePrice = baseline.BaseMarketValue;
                    float ingredientPrice = extension.useCap ? Math.Min(productIngredient.BaseMarketValue, basePrice * extension.capPriceInfluenceMultiplier) : productIngredient.BaseMarketValue;

                    if (productIngredientPlant != null && baselinePlant != null)
                    {
                        float baselineTime = baselinePlant.plant.growDays;
                        float baselineYield = baselinePlant.plant.harvestYield;

                        float ingredientTime = productIngredientPlant.plant.growDays;
                        float ingredientYield = productIngredientPlant.plant.harvestYield;


                        resultingStack = (int)(__result.stackCount * (ingredientPrice / basePrice) * ((baselineYield / baselineTime) / (ingredientYield / ingredientTime)));
                    }
                    else
                    {
                        resultingStack = (int)(__result.stackCount * (ingredientPrice / basePrice));


                    }

                    if (resultingStack == 0)
                    {
                        resultingStack = 1;
                    }


                   

                }




                
            }
            if (recipeDef.defName.Contains("AC_"))
            {
                resultingStack = (int)(resultingStack * worker.GetStatValue(InternalDefOf.AC_ArtisanalCraftingYield));

            }
            __result.stackCount = resultingStack;
        }
    }
}