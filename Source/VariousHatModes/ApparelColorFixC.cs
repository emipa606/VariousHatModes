using HarmonyLib;
using UnityEngine;
using Verse;

namespace VariousHatModes
{
    // Token: 0x02000004 RID: 4
    [HarmonyPatch(typeof(ThingMaker))]
    [HarmonyPatch("MakeThing")]
    public static class ApparelColorFixC
    {
        // Token: 0x06000003 RID: 3 RVA: 0x0000214C File Offset: 0x0000034C
        [HarmonyPostfix]
        private static void Postfix(ref Thing __result)
        {
            ThingWithComps thingWithComps;
            var flag = (thingWithComps = __result as ThingWithComps) != null;
            if (!flag)
            {
                return;
            }

            DisableApparelColor disableApparelColor;
            var flag2 = (disableApparelColor = thingWithComps.def as DisableApparelColor) != null &&
                        !disableApparelColor.ApparelColor;
            if (!flag2)
            {
                return;
            }

            thingWithComps.SetColor(Color.white);
            thingWithComps.SetColor(Color.black);
            thingWithComps.SetColor(Color.white);
        }
    }
}