using System.Linq;
using Verse;

namespace AnimalArmourFix
{
    [StaticConstructorOnStartup]
    public static class AnimalArmourFix
    {
        static AnimalArmourFix()
        {
            var animalsInGame = (from animal in DefDatabase<ThingDef>.AllDefsListForReading
                where animal.race is {Animal: true}
                select animal).ToList();
            foreach (var animalDef in animalsInGame)
            {
                switch (animalDef.race.baseBodySize)
                {
                    case >= 2.4f:
                        animalDef.recipes.Add(DefDatabase<RecipeDef>.GetNamed("InstallMakeshiftAnimalArmorHuge",
                            false));
                        animalDef.recipes.Add(DefDatabase<RecipeDef>.GetNamed("InstallStandardAnimalArmorHuge", false));
                        animalDef.recipes.Add(DefDatabase<RecipeDef>.GetNamed("InstallHeavyAnimalArmorHuge", false));
                        animalDef.recipes.Add(DefDatabase<RecipeDef>.GetNamed("RemoveMakeshiftAnimalArmorHuge", false));
                        animalDef.recipes.Add(DefDatabase<RecipeDef>.GetNamed("RemoveStandardAnimalArmorHuge", false));
                        animalDef.recipes.Add(DefDatabase<RecipeDef>.GetNamed("RemoveHeavyAnimalArmorHuge", false));
                        break;
                    case >= 1.3f:
                        animalDef.recipes.Add(
                            DefDatabase<RecipeDef>.GetNamed("InstallMakeshiftAnimalArmorLarge", false));
                        animalDef.recipes.Add(DefDatabase<RecipeDef>.GetNamed("InstallStandardAnimalArmorLarge",
                            false));
                        animalDef.recipes.Add(DefDatabase<RecipeDef>.GetNamed("InstallHeavyAnimalArmorLarge", false));
                        animalDef.recipes.Add(DefDatabase<RecipeDef>.GetNamed("RemoveMakeshiftAnimalArmorLarge",
                            false));
                        animalDef.recipes.Add(DefDatabase<RecipeDef>.GetNamed("RemoveStandardAnimalArmorLarge", false));
                        animalDef.recipes.Add(DefDatabase<RecipeDef>.GetNamed("RemoveHeavyAnimalArmorLarge", false));
                        break;
                    case >= 0.7f:
                        animalDef.recipes.Add(DefDatabase<RecipeDef>.GetNamed("InstallMakeshiftAnimalArmorMedium",
                            false));
                        animalDef.recipes.Add(
                            DefDatabase<RecipeDef>.GetNamed("InstallStandardAnimalArmorMedium", false));
                        animalDef.recipes.Add(DefDatabase<RecipeDef>.GetNamed("InstallHeavyAnimalArmorMedium", false));
                        animalDef.recipes.Add(
                            DefDatabase<RecipeDef>.GetNamed("RemoveMakeshiftAnimalArmorMedium", false));
                        animalDef.recipes.Add(DefDatabase<RecipeDef>.GetNamed("RemoveStandardAnimalArmorMedium",
                            false));
                        animalDef.recipes.Add(DefDatabase<RecipeDef>.GetNamed("RemoveHeavyAnimalArmorMedium", false));
                        break;
                    case >= 0.3f:
                        animalDef.recipes.Add(
                            DefDatabase<RecipeDef>.GetNamed("InstallMakeshiftAnimalArmorSmall", false));
                        animalDef.recipes.Add(DefDatabase<RecipeDef>.GetNamed("InstallStandardAnimalArmorSmall",
                            false));
                        animalDef.recipes.Add(DefDatabase<RecipeDef>.GetNamed("InstallHeavyAnimalArmorSmall", false));
                        animalDef.recipes.Add(DefDatabase<RecipeDef>.GetNamed("RemoveMakeshiftAnimalArmorSmall",
                            false));
                        animalDef.recipes.Add(DefDatabase<RecipeDef>.GetNamed("RemoveStandardAnimalArmorSmall", false));
                        animalDef.recipes.Add(DefDatabase<RecipeDef>.GetNamed("RemoveHeavyAnimalArmorSmall", false));
                        break;
                    default:
                        animalDef.recipes.Add(DefDatabase<RecipeDef>.GetNamed("InstallMakeshiftAnimalArmorTiny",
                            false));
                        animalDef.recipes.Add(DefDatabase<RecipeDef>.GetNamed("InstallStandardAnimalArmorTiny", false));
                        animalDef.recipes.Add(DefDatabase<RecipeDef>.GetNamed("InstallHeavyAnimalArmorTiny", false));
                        animalDef.recipes.Add(DefDatabase<RecipeDef>.GetNamed("RemoveMakeshiftAnimalArmorTiny", false));
                        animalDef.recipes.Add(DefDatabase<RecipeDef>.GetNamed("RemoveStandardAnimalArmorTiny", false));
                        animalDef.recipes.Add(DefDatabase<RecipeDef>.GetNamed("RemoveHeavyAnimalArmorTiny", false));
                        break;
                }
            }

            if (Prefs.DevMode)
            {
                Log.Message($"XND Animal Armour: Added armour recipies to {animalsInGame.Count} animal-spieces");
            }
        }
    }
}