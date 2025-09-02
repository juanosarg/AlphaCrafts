using RimWorld;
using System.Collections.Generic;
using Verse;
using System.Linq;
using static UnityEngine.GraphicsBuffer;
namespace AlphaCrafts
{
    public class CompUseEffect_ReduceInfections : CompTargetEffect
    {
        public CompProperties_UseEffectReduceInfections Props => (CompProperties_UseEffectReduceInfections)props;

        public override void DoEffectOn(Pawn user, Thing thing)
        {
          
            Pawn pawn = thing as Pawn;
            List<Hediff> infections = pawn.health.hediffSet.hediffs.Where((Hediff hediff) => hediff.def == HediffDefOf.WoundInfection).ToList();
            if (infections.Count > 0)
            {
                float MaxSeverity = 0;
                Hediff infectionChosen = null;
                foreach (Hediff infection in infections)
                {
                    if (infection.Severity > MaxSeverity)
                    {
                        MaxSeverity = infection.Severity;
                        infectionChosen = infection;
                    }
                }
                if (infectionChosen != null)
                {
                    infectionChosen.Severity -= Props.reduction;
                }
            }
            user.carryTracker.DestroyCarriedThing();
        }

        public override bool CanApplyOn(Thing target)
        {
            Pawn p = target as Pawn;
            if (p == null || !p.RaceProps.Humanlike)
            {
                return false;
            }
            if (p.IsGhoul)
            {
                return false;
            }

            return true;
        }
    }
}
