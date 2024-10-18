
using HarmonyLib;
using JetBrains.Annotations;
using RimWorld;
using System.Linq;
using UnityEngine;
using Verse;

namespace AlphaCrafts
{
    [HarmonyPatch(typeof(CompIngredients), "GetFoodKindInspectString")]
    public class AlphaCrafts_CompIngredients_GetFoodKindInspectString_Patch
    {
        [HarmonyPostfix]
        private static void PostFix(CompIngredients __instance, ref string __result)
        {
            if (!__instance.parent.def.IsIngestible)
            {

                __result = "-";

            }
        }
    }
}