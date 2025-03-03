﻿using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Verse;
using RimWorld;
using UnityEngine.Diagnostics;

namespace AlphaCrafts
{
    public class Graphic_StackCountByIngredient
        : Graphic_Collection
    {

        public override Material MatSingle => subGraphics[subGraphics.Length - 1].MatSingle;

        public override Graphic GetColoredVersion(Shader newShader, Color newColor, Color newColorTwo)
        {
            return GraphicDatabase.Get<Graphic_StackCount>(path, newShader, drawSize, newColor, newColorTwo, data);
        }

        public override Material MatAt(Rot4 rot, Thing thing = null)
        {
            if (thing == null)
            {
                return MatSingle;
            }
            return MatSingleFor(thing);
        }

        public override Material MatSingleFor(Thing thing)
        {
            if (thing == null)
            {
                return MatSingle;
            }
            return SubGraphicFor(thing).MatSingle;
        }

        public Graphic SubGraphicFor(Thing thing)
        {
            return SubGraphicForStackCount(thing.stackCount, thing.def, thing);
        }

        public override void DrawWorker(Vector3 loc, Rot4 rot, ThingDef thingDef, Thing thing, float extraRotation)
        {
            Graphic graphic = (thing == null) ? subGraphics[0] : SubGraphicFor(thing);
            graphic.DrawWorker(loc, rot, thingDef, thing, extraRotation);
        }

        public virtual Graphic SubGraphicForStackCount(int stackCount, ThingDef def, Thing thing)
        {
            return null;
        }

        public override string ToString()
        {
            return "StackCount(path=" + path + ", count=" + subGraphics.Length + ")";
        }


    }
}


