using HarmonyLib;
using RimWorld;
using System.Reflection;
using Verse;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using Verse.AI;
using AlphaCrafts;



namespace AlphaCrafts
{


    [HarmonyPatch(typeof(Thought_Memory))]
    [HarmonyPatch("DurationTicks", MethodType.Getter)]
    public static class AlphaCrafts_Thought_Memory_DurationTicks_Patch
    {
        [HarmonyPostfix]
        public static void ModifyDuration(ref int __result, Thought_Memory __instance)
        {
            
            if (__instance.pawn!=null&&__instance?.moodOffset < 0 && StaticCollections.pawnMoodTimeMultiplier.ContainsKey(__instance.pawn))
            {
                __result = (int)(__result * StaticCollections.pawnMoodTimeMultiplier[__instance.pawn]);
            }



        }
    }








}
