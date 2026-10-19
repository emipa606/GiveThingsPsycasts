# Copilot Instructions for RimWorld Mod: Give Things Psycasts

## Overview

### Mod Name: Give Things Psycasts
**Author**: Mlie  
**PackageId**: Mlie.GiveThingsPsycasts

**Description**:  
The "Give Things Psycasts" mod enables other mods to add Psycasts to Apparel and Hediffs, providing the wearer with psycasting abilities regardless of whether the pawn is normally psycast-enabled. This functionality is achieved by using a custom component defined in this mod, allowing the integration of custom psycasts by specifying their `defName`.

## Purpose

The primary purpose of this mod is to expand the psycasting capabilities within RimWorld, enabling non-psycast pawns to utilize psycasts through the use of special apparel or conditions caused by hediffs. By doing so, this mod aims to increase gameplay flexibility and potential synergy between different mods and custom content.

## Key Features and Systems

- **Component-based Psycast Granting**: The mod uses components (`Comp`) to bestow psycast abilities on pawns wearing specific apparel or affected by particular hediffs.
- **Custom Psycast Support**: Allows integration of custom psycasts via the `defName` property, enabling modders to create diverse and unique psycast experiences.
- **Template for Easy Integration**: A Def-directory template is provided to facilitate straightforward integration for other mods. Mod authors are encouraged to refer to this template for guidance on implementation.

## Coding Patterns and Conventions

- **Consistent Naming Conventions**: Types and members follow a PascalCase naming convention, consistent with C# standards.
- **Component Use**: The mod heavily utilizes components (`Comp`) to modularize the functionality, ensuring a flexible and extensible system for future adjustments and expansions.
- **Conditional Checks**: Functions like `GetWearer` and `IsWorn` are used to determine whether psycasts should be available, ensuring the system only grants abilities under appropriate conditions.

## XML Integration

While there are no XML files directly associated with this mod, mod developers should refer to the template available in the Def-directory to integrate the component in their own XML files effectively. This template guides the addition of the necessary components and properties that enable psycast functionalities.

## Harmony Patching

Harmony is used to seamlessly integrate the mod's functionalities into the existing game without directly altering the vanilla codebase. The following outlines the harmony patching strategy:

- **Method Patching**: The mod uses Harmony to patch methods related to apparel and hediffs to inject custom psycast abilities.
- **Gizmo Retrieval**: Through classes like `Apparel_GetWornGizmos`, harmony ensures that the gizmos (UI elements for interacting with psycasts) are properly assigned and displayed when appropriate.

## Suggestions for Copilot

When developing or expanding this mod with Copilot, consider the following suggestions to enhance code generation and integration:

1. **Component Design Patterns**: Encourage Copilot to generate additional components following the structure of `CompGiveThingsPsycasts` and `CompGiveHediffsPsycasts`, facilitating the addition of new features with minimal effort.
   
2. **Template-Based XML Advice**: Suggest Copilot to provide XML template snippets based on the Def-directory example, helping modders to replicate and adapt the component integration process for their custom psycasts.

3. **Harmony Patching Templates**: Guide Copilot to offer harmony patch templates that align with existing patterns, emphasizing method prefixing and postfixing where applicable to ensure smooth interoperability with other mods.

4. **Potential Debugging Tools**: Encourage Copilot to propose logging or debugging mechanisms that align with the RimWorld modding environment to assist in troubleshooting integration issues effectively.

This document provides an extensive guide to the "Give Things Psycasts" mod's architecture, enabling modders to create new content with ease and extend scalability within RimWorld.

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

