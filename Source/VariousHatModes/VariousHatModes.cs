using System.Reflection;
using HarmonyLib;
using Verse;

namespace VariousHatModes
{
    // Token: 0x02000006 RID: 6
    [StaticConstructorOnStartup]
    public static class VariousHatModes
    {
        // Token: 0x06000005 RID: 5 RVA: 0x000021C4 File Offset: 0x000003C4
        static VariousHatModes()
        {
            var harmonyInstance = new Harmony("com.rimworld.Dalrae.VariousHatModes");
            harmonyInstance.PatchAll(Assembly.GetExecutingAssembly());
        }
    }
}