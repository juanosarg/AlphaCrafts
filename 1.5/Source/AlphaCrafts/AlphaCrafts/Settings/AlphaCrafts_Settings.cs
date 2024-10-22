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

        public const float AC_QuestRateBase = 1;
        public float AC_QuestRate = AC_QuestRateBase;
        public bool AC_DisableQuests = false;




        private static Vector2 scrollPosition = Vector2.zero;

        public override void ExposeData()
        {
            base.ExposeData();

            Scribe_Values.Look(ref AC_QuestRate, "AC_QuestRate", AC_QuestRateBase);
            Scribe_Values.Look(ref AC_DisableQuests, "AC_DisableQuests", false);
          


        }
        public void DoWindowContents(Rect inRect)
        {
            Listing_Standard listingStandard = new Listing_Standard();

            var scrollContainer = inRect.ContractedBy(10);
            scrollContainer.height -= listingStandard.CurHeight;
            scrollContainer.y += listingStandard.CurHeight;
            Widgets.DrawBoxSolid(scrollContainer, Color.grey);
            var innerContainer = scrollContainer.ContractedBy(1);
            Widgets.DrawBoxSolid(innerContainer, new ColorInt(42, 43, 44).ToColor);
            var frameRect = innerContainer.ContractedBy(5);
            frameRect.y += 15;
            frameRect.height -= 15;
            var contentRect = frameRect;
            contentRect.x = 0;
            contentRect.y = 0;
            contentRect.width -= 20;

            contentRect.height = 950f;

            Widgets.BeginScrollView(frameRect, ref scrollPosition, contentRect, true);
            listingStandard.Begin(contentRect.AtZero());

            var QuestRateLabel = listingStandard.LabelPlusButton("AC_QuestRate".Translate() + ": " + AC_QuestRate, "AC_QuestRateTooltip".Translate());
            AC_QuestRate = (float)Math.Round(listingStandard.Slider(AC_QuestRate, 0.1f, 5f), 1);
            if (listingStandard.Settings_Button("AC_Reset".Translate(), new Rect(0f, QuestRateLabel.position.y + 35, 180f, 29f)))
            {
                AC_QuestRate = AC_QuestRateBase;
            }
            listingStandard.CheckboxLabeled("AC_DisableQuests".Translate(), ref AC_DisableQuests, "AC_DisableQuests_Description".Translate());
            



            listingStandard.End();
            Widgets.EndScrollView();

            base.Write();

        }

    }


}
