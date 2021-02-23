using HarmonyLib;
using RimWorld;
using UnityEngine;
using Verse;

namespace VariousHatModes
{
    // Token: 0x02000002 RID: 2
    [HarmonyPatch(typeof(PawnApparelGenerator))]
    [HarmonyPatch("GenerateStartingApparelFor")]
    public static class ApparelColorFixA
    {
        // Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
        [HarmonyPostfix]
        private static void Postfix(ref Pawn pawn)
        {
            var flag = pawn.apparel == null;
            if (flag)
            {
                return;
            }

            var wornApparel = pawn.apparel.WornApparel;
            foreach (var apparel in wornApparel)
            {
                DisableApparelColor disableApparelColor;
                var flag2 = (disableApparelColor = apparel.def as DisableApparelColor) != null &&
                            !disableApparelColor.ApparelColor;
                if (!flag2)
                {
                    continue;
                }

                apparel.SetColor(Color.white);
                apparel.SetColor(Color.black);
                apparel.SetColor(Color.white);
            }
        }
    }
}