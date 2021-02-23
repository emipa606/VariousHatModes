using HarmonyLib;
using UnityEngine;
using Verse;

namespace VariousHatModes
{
    // Token: 0x02000003 RID: 3
    [HarmonyPatch(typeof(GenRecipe))]
    [HarmonyPatch("PostProcessProduct")]
    public static class ApparelColorFixB
    {
        // Token: 0x06000002 RID: 2 RVA: 0x000020FC File Offset: 0x000002FC
        [HarmonyPrefix]
        private static void Prefix(ref Thing product)
        {
            ThingWithComps thingWithComps;
            var flag = (thingWithComps = product as ThingWithComps) != null;
            if (!flag)
            {
                return;
            }

            DisableApparelColor disableApparelColor;
            var flag2 = (disableApparelColor = thingWithComps.def as DisableApparelColor) != null &&
                        !disableApparelColor.ApparelColor;
            if (flag2)
            {
                thingWithComps.SetColor(Color.white);
            }
        }
    }
}