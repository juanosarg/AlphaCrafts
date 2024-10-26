using RimWorld;
using UnityEngine;
using Verse;
using System;
using System.Collections.Generic;
using System.Linq;


namespace AlphaCrafts
{
    public class AlphaCrafts_Settings : ModSettings

    {

        public const float AC_MarketValueModifierBase = 1;
        public float AC_MarketValueModifier = AC_MarketValueModifierBase;
        public const float AC_QuestRateBase = 1;
        public float AC_QuestRate = AC_QuestRateBase;
        public bool AC_DisableQuests = false;




       

        public override void ExposeData()
        {
            base.ExposeData();

            Scribe_Values.Look(ref AC_QuestRate, "AC_QuestRate", AC_QuestRateBase);
            Scribe_Values.Look(ref AC_DisableQuests, "AC_DisableQuests", false);
            Scribe_Values.Look(ref AC_MarketValueModifier, "AC_MarketValueModifier", AC_MarketValueModifierBase);


        }
        public void DoWindowContents(Rect inRect)
        {
            Listing_Standard listingStandard = new Listing_Standard();

            listingStandard.Begin(inRect);

            var MarketValueLabel = listingStandard.LabelPlusButton("AC_MarketValueModifier".Translate() + ": " + AC_MarketValueModifier, "AC_MarketValueModifierTooltip".Translate());
            AC_MarketValueModifier = (float)Math.Round(listingStandard.Slider(AC_MarketValueModifier, 0.1f, 5f), 1);
            if (listingStandard.Settings_Button("AC_Reset".Translate(), new Rect(0f, MarketValueLabel.position.y + 35, 180f, 29f)))
            {
                AC_MarketValueModifier = AC_MarketValueModifierBase;
            }

            var QuestRateLabel = listingStandard.LabelPlusButton("AC_QuestRate".Translate() + ": " + AC_QuestRate, "AC_QuestRateTooltip".Translate());
            AC_QuestRate = (float)Math.Round(listingStandard.Slider(AC_QuestRate, 0.1f, 5f), 1);
            if (listingStandard.Settings_Button("AC_Reset".Translate(), new Rect(0f, QuestRateLabel.position.y + 35, 180f, 29f)))
            {
                AC_QuestRate = AC_QuestRateBase;
            }
            listingStandard.CheckboxLabeled("AC_DisableQuests".Translate(), ref AC_DisableQuests, "AC_DisableQuests_Description".Translate());
            



            listingStandard.End();
          

            base.Write();

        }

    }


}
