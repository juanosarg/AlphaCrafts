
using HarmonyLib;
using JetBrains.Annotations;
using RimWorld;
using System.Linq;
using UnityEngine;
using Verse;

namespace AlphaCrafts
{
    [HarmonyPatch(typeof(GenRecipe), "PostProcessProduct")]
    public class AlphaCrafts_GenRecipe_PostProcessProduct_Patch
    {
        [HarmonyPostfix]
        private static void PostFix(Thing product, RecipeDef recipeDef, ref Thing __result)
        {
            if (recipeDef.GetModExtension<VariableOutputByIngredient>() != null)
            {
               
                ThingDef baseline = recipeDef.GetModExtension<VariableOutputByIngredient>().baseline;
           
                ThingDef baselinePlant = DefDatabase<ThingDef>.AllDefsListForReading.Where(x => x.plant?.harvestedThingDef == baseline).FirstOrFallback(null);

                ThingDef productIngredient = null;
                ThingDef productIngredientPlant = null;

                CompIngredients compIngredients = product.TryGetComp<CompIngredients>();
                if (compIngredients != null)
                {
                    productIngredient = compIngredients.ingredients.First();
                    productIngredientPlant = DefDatabase<ThingDef>.AllDefsListForReading.Where(x => x.plant?.harvestedThingDef == productIngredient).FirstOrFallback(null);

                }


                if (baselinePlant != null)
                {
                    int resultingStack = __result.stackCount;

                    float basePrice = baseline.BaseMarketValue;
                    float ingredientPrice = productIngredient.BaseMarketValue;

                    if (productIngredientPlant != null)
                    {
                        float baselineTime = baselinePlant.plant.growDays;
                        float baselineYield = baselinePlant.plant.harvestYield;

                        float ingredientTime = productIngredientPlant.plant.growDays;
                        float ingredientYield = productIngredientPlant.plant.harvestYield;


                        resultingStack = (int)(__result.stackCount * (ingredientPrice/ basePrice) * ((baselineYield / baselineTime) / (ingredientYield / ingredientTime)));
                    }
                    else
                    {
                        resultingStack = (int)(__result.stackCount * (ingredientPrice / basePrice));


                    }

                    if (resultingStack == 0)
                    {
                        resultingStack = 1;
                    }


                    __result.stackCount = resultingStack;

                }




            }
        }
    }
}