using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using RimWorld;
using Verse.AI.Group;
using Verse;
using RimWorld.QuestGen;
using LudeonTK;
using AlphaCrafts;
using static HarmonyLib.Code;

namespace AlphaGenes
{
    public static class GenerateArtisanTradingQuest
    {


        [DebugAction("Alpha Crafts", "Generate Artisan Trading quest", false, false, allowedGameStates = AllowedGameStates.PlayingOnMap)]
        private static void GenerateLabQuest()
        {

            Slate slate = new Slate();

            if (InternalDefOf.AC_ArtisanTradeRequest.CanRun(slate))
            {
                Quest quest = QuestUtility.GenerateQuestAndMakeAvailable(InternalDefOf.AC_ArtisanTradeRequest, slate);

                QuestUtility.SendLetterQuestAvailable(quest);

            }
            else
            {
                Messages.Message("AC_CantRunQuest".Translate(), null, MessageTypeDefOf.NegativeEvent);
            }



        }




    }
}

