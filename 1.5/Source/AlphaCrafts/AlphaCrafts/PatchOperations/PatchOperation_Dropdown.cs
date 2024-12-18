using System.Collections.Generic;
using System.Linq;
using System.Xml;
using Verse;

namespace AlphaCrafts
{
    public class PatchOperation_Dropdown : PatchOperation
    {

        private PatchOperation match;

        private PatchOperation nomatch;

        protected override bool ApplyWorker(XmlDocument xml)
        {

            if (AlphaCrafts_Mod.settings.AC_UseDropdownForMachines)
            {
                if (match != null)
                {
                    return match.Apply(xml);
                }
            }
            else if (nomatch != null)
            {
                return nomatch.Apply(xml);
            }
            return true;
        }


    }
}