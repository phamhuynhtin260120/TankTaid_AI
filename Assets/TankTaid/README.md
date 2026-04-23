# TankTaid Unity Structure

This folder is the working home for prototype gameplay code and content.

## Suggested usage

- `Art/`: prefabs, models, materials, VFX, and UI art assets owned by the game.
- `Audio/`: music and sound effects.
- `Content/`: ScriptableObjects, balance data, and game definitions.
- `Scenes/`: gameplay scenes split by flow (`Bootstrap`, `Garage`, `Mission`, `Raid`, `HomeDefense`).
- `Scripts/Core/`: bootstrapping, shared services, and cross-feature foundations.
- `Scripts/Gameplay/`: feature code grouped by gameplay domain.
- `Scripts/Networking/`: WebSocket client, DTO mapping, connection state.
- `Scripts/UI/`: HUD, menus, raid result, garage flow.
- `Settings/`: input and project-level game settings that belong to TankTaid.
- `Tests/`: edit mode and play mode tests.

## Prototype-first rule

Keep code grouped by feature before introducing deeper technical layers.
