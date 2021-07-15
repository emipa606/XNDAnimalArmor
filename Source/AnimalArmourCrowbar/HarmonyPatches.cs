using HarmonyLib;
using RimWorld;
using Verse;

namespace AnimalArmourFix
{
    // Token: 0x02000002 RID: 2
    [StaticConstructorOnStartup]
    internal static class HarmonyPatches
    {
        // Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
        static HarmonyPatches()
        {
            var harmonyInstance = new Harmony("mehni.rimworld.animalarmour.main");
            harmonyInstance.Patch(AccessTools.Method(typeof(Recipe_RemoveHediff), "ApplyOnPawn"),
                new HarmonyMethod(typeof(HarmonyPatches), "RemoveHediff_Prefix"));
            harmonyInstance.Patch(AccessTools.Method(typeof(Recipe_RemoveHediff), "ApplyOnPawn"), null,
                new HarmonyMethod(typeof(HarmonyPatches), "RemoveHediff_Postfix"));
            harmonyInstance.Patch(AccessTools.Method(typeof(Recipe_InstallImplant), "ApplyOnPawn"),
                new HarmonyMethod(typeof(HarmonyPatches), "SpawnHediff_Prefix"));
        }

        // Token: 0x06000002 RID: 2 RVA: 0x00002100 File Offset: 0x00000300
        private static void RemoveHediff_Prefix(Recipe_RemoveHediff __instance, ref Pawn pawn, ref BodyPartRecord part,
            out Hediff __state)
        {
            var currentPart = part;
            var hediff = pawn.health.hediffSet.hediffs.Find(x =>
                x.def == __instance.recipe.removesHediff && x.Part == currentPart && x.Visible);
            __state = hediff;
        }

        // Token: 0x06000003 RID: 3 RVA: 0x00002148 File Offset: 0x00000348
        private static void RemoveHediff_Postfix(ref Pawn billDoer, Hediff __state)
        {
            Log.Message(__state.def.defName);
            if (__state.def.defName.Contains("AnimalArmor") &&
                __state.def.spawnThingOnRemoved != null)
            {
                GenSpawn.Spawn(__state.def.spawnThingOnRemoved, billDoer.Position, billDoer.Map);
            }
        }

        // Token: 0x06000004 RID: 4 RVA: 0x000021B0 File Offset: 0x000003B0
        private static void SpawnHediff_Prefix(Recipe_InstallImplant __instance, ref Pawn pawn, ref BodyPartRecord part,
            ref Pawn billDoer)
        {
            if (pawn.RaceProps.Humanlike || __instance.recipe.addsHediff == null ||
                !__instance.recipe.addsHediff.defName.Contains("AnimalArmor"))
            {
                return;
            }

            var hediffs = pawn.health.hediffSet.hediffs;
            for (var i = hediffs.Count - 1; i >= 0; i--)
            {
                var hediff = hediffs[i];
                if (hediff.Part != part || !hediff.def.defName.Contains("AnimalArmor") ||
                    hediff.def.defName == __instance.recipe.addsHediff.defName)
                {
                    continue;
                }

                var hediff2 = hediffs[i];
                pawn.health.RemoveHediff(hediff2);
                GenSpawn.Spawn(hediff2.def.spawnThingOnRemoved, billDoer.Position, billDoer.Map);
            }
        }
    }
}