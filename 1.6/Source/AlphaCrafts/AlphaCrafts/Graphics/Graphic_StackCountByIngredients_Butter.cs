using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Verse;
using RimWorld;
using UnityEngine.Diagnostics;

namespace AlphaCrafts
{
    public class Graphic_StackCountByIngredients_Butter
        : Graphic_StackCountByIngredient
    {

        public int cachedOffset = -1;
    

        public override Graphic SubGraphicForStackCount(int stackCount, ThingDef def, Thing thing)
        {
            int offsetToAdd = cachedOffset;
            if (offsetToAdd == -1)
            {
                offsetToAdd = Utils.GetGraphicNumberOffsetForButter(thing);
            }

            if (stackCount == 1)
            {
                return subGraphics[0 + offsetToAdd * 3];
            }
            if (stackCount == def.stackLimit)
            {
                return subGraphics[2 + offsetToAdd * 3];
            }
            return subGraphics[1 + offsetToAdd * 3];

        }

      
    }
}


