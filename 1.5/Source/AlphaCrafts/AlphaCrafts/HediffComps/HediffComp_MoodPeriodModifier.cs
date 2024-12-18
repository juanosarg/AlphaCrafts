
using AlphaCrafts;
using RimWorld;
using UnityEngine;
using Verse;

namespace AlphaCrafts
{
    public class HediffComp_MoodPeriodModifier : HediffComp
    {


        public HediffCompProperties_MoodPeriodModifier Props => (HediffCompProperties_MoodPeriodModifier)props;


        public override void CompPostTick(ref float severityAdjustment)
        {
            Pawn pawn = this.parent.pawn;
            if (pawn.IsHashIntervalTick(200))
            {
                StaticCollections.AddPawnMoodTimeMultiplierToList(this.parent.pawn, 0.8f);
            }
        }


        public override void CompPostPostAdd(DamageInfo? dinfo)
        {

            StaticCollections.AddPawnMoodTimeMultiplierToList(this.parent.pawn, 0.8f);

        }

        public override void CompPostPostRemoved()
        {
            StaticCollections.RemovePawnMoodTimeMultiplierFromList(this.parent.pawn);

        }

        public override void Notify_PawnDied(DamageInfo? dinfo, Hediff culprit = null)
        {
            StaticCollections.RemovePawnMoodTimeMultiplierFromList(this.parent.pawn);

        }

        public override void Notify_PawnKilled()
        {
            StaticCollections.RemovePawnMoodTimeMultiplierFromList(this.parent.pawn);

        }


    }
}