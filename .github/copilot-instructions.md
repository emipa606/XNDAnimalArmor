# GitHub Copilot Instructions for [XND] Animal Armor (Continued)

## Mod Overview and Purpose

The [XND] Animal Armor mod is an enhancement of XeoNovaDan's original mod, aimed at providing players the ability to craft and equip armor for their animals in RimWorld. Designed for players who want to equip their animal companions with protective gear, this mod offers a dynamic system that scales with various animal body sizes, ensuring compatibility and ease of use across the board.

## Key Features and Systems

- **Dynamic Armor Recipes:** Instead of a static patch system, armor recipes are dynamically created via C# code, allowing seamless integration with all animals based on their body size. This ensures that armor can be appropriately sized for different animals, from tiny squirrels to huge elephants.
- **Armor Variations:**
  - **Makeshift Armor:** Low-tech option with basic protection.
  - **Standard Armor:** Balanced protection with modern materials.
  - **Heavy Armor:** High protection at the cost of reduced movement speed.
- **Size Categories:** Armor sizes are determined by animal body size, with five categories from Tiny to Huge.
- **Medical Considerations:** Animals require anesthesia when their armor is changed, reflecting their natural resistance to human handling.
- **Compatibility:** Works smoothly with Vanilla-Friendly Animal Surgery, A Dog Said, and other animal mods, although additional XML patches are required for complete integration.

## Coding Patterns and Conventions

- **Object-Oriented Programming:** The mod employs robust C# classes for managing dynamic functionalities.
- **Dynamic Recipe Management:** Utilizes best practices in dynamically adding and managing recipes using C#.
- **Consistent Naming Conventions:** Follows clear and descriptive naming for classes and methods to enhance readability.
- **Modularity:** Each class and method is designed to be modular, allowing ease of modification and expansion.

## XML Integration

- **XML Defs:** While mainly managed via C#, the mod maintains a comprehensive set of XML definitions, including `<HediffDef>`, `<ResearchProjectDef>`, and `<RecipeDef>`.
- **Def Structure:** Ensure correct namespace usage and alignment with existing mod paradigms in RimWorld.
- **Compatibility Patches:** Additional XML patches may be developed for specific animal mod integrations.

## Harmony Patching

- **Functionality Enhancements:** The mod uses the Harmony library for method prefix and postfix patching, interacting with RimWorld’s core game functions.
- **Patch Files:** Key patches are handled in `HarmonyPatches.cs`, adjusting behaviors related to `RemoveHediff` and `SpawnHediff`.
- **Robustness:** Patches are carefully implemented to maintain game stability and enhance the base functionality without introducing errors.

## Suggestions for Copilot

- **Code Generation Assistance:** Utilize Copilot to suggest completion for repetitive XML elements and C# boilerplate code, like class definitions and method stubs.
- **Dynamic Code Blocks:** Employ Copilot’s AI capabilities to explore new coding approaches for dynamic recipe creation and altering, potentially introducing optimizations.
- **Error Checking:** Leverage Copilot to automatically suggest error checks and exception handling for Harmony patches and dynamic recipe generation.
- **Modular Code Integration:** Suggest improvements for integrating new animal sizings or other functionalities with minimal disruption to existing code structure.

By following these guidelines, contributors can efficiently develop, maintain, and expand the [XND] Animal Armor mod with advanced automation features and compatibility considerations provided by GitHub Copilot. Please ensure all changes are tested in isolation as well as within the context of a fully modded game environment to ensure compatibility and performance integrity.

## Project Solution Guidelines
- Relevant mod XML files are included as Solution Items under the solution folder named XML, these can be read and modified from within the solution.
- Use these in-solution XML files as the primary files for reference and modification.
- The `.github/copilot-instructions.md` file is included in the solution under the `.github` solution folder, so it should be read/modified from within the solution instead of using paths outside the solution. Update this file once only, as it and the parent-path solution reference point to the same file in this workspace.
- When making functional changes in this mod, ensure the documented features stay in sync with implementation; use the in-solution `.github` copy as the primary file.
- In the solution is also a project called Assembly-CSharp, containing a read-only version of the decompiled game source, for reference and debugging purposes.
- For any new documentation, update this copilot-instructions.md file rather than creating separate documentation files.


## Hard rules (must follow)
- Do NOT run commands that modify the repo (no git commit, git apply, dotnet format) unless explicitly asked.
- Prefer minimal reads: read only the smallest code region needed (around the suspicious lines).
- When mentioning SonarQube issues, automatically use the SonarQube MCP service to fetch and address issues instead of making inferred fixes without querying SonarQube first.
- When mentioning the rimworld log, automatically use the Rimworld MCP service to fetch the log.

