# Technical Breakdown

## Project Summary

TORO is an interactive VR garden experience designed around calm exploration and simple embodied interactions. The player enters a Japanese garden, reads tutorial prompts, lights stone lanterns, and interacts with collectible flowers.

The technical work centered on turning a visual environment into a responsive simulation: controller input, raycast targeting, trigger volumes, runtime object feedback, UI state changes, and scene-level integration.

## Main Gameplay Systems

### 1. Tutorial Flow

The tutorial flow uses `InputActionReference` to read controller input and `Physics.Raycast` to detect whether the player is targeting a UI-layer object. When the player activates the target, the tutorial panel is hidden.

Key implementation details:

- Reads trigger/button values through Unity Input System.
- Uses a raycast from the controller or camera transform.
- Restricts hits to a target layer.
- Updates UI state by activating/deactivating GameObjects.

Script:

- `src/UnityScripts/TutorialStart.cs`

### 2. Ray-Based Lantern Interaction

The lantern interaction follows a similar pattern: read controller activation, raycast against target objects, then spawn a flame prefab as visual feedback.

Key implementation details:

- Uses layer filtering to avoid unintended targets.
- Instantiates a flame prefab at an offset from the target object.
- Uses a trigger guard to prevent repeated spawning while the input remains held.
- Uses debug rays/logs during development to verify targeting.

Script:

- `src/UnityScripts/HitRayHand.cs`

### 3. Collection and Basket Feedback

The basket system receives collectible objects through a trigger collider. When a tagged object enters, it increments a count, updates TextMeshPro UI, destroys the collected object, and spawns a flower feedback object.

Key implementation details:

- Uses `OnTriggerEnter(Collider other)`.
- Checks object tags before handling collection.
- Updates TextMeshPro text for player feedback.
- Destroys collected objects to update world state.
- Uses a coroutine to temporarily guard against duplicate trigger events.

Script:

- `src/UnityScripts/BasketInteraction.cs`

### 4. Player Control Prototypes

The repository includes early movement prototypes used while testing the environment outside the final VR interaction path.

Scripts:

- `src/UnityScripts/PlayerMovement.cs`
- `src/UnityScripts/FirstPersonControl.cs`

## Unity Concepts Demonstrated

- MonoBehaviour lifecycle methods: `Start`, `Update`, `OnTriggerEnter`
- Unity Input System with `InputActionReference`
- Physics raycasts and trigger colliders
- Layer masks, tags, and object filtering
- Runtime prefab instantiation
- Runtime object destruction
- Coroutine-based temporary state changes
- TextMeshPro UI updates
- Scene integration and VR interaction setup

## Why This Matters

The project demonstrates:

- converting user input into predictable system behavior
- mapping spatial interaction to runtime state changes
- debugging interaction targets through layers, tags, and visual rays
- connecting UI, environment objects, and player feedback
- building small gameplay systems that can be tested and tuned in Unity

## Production Follow-Up Ideas

If revisiting this project, I would focus on maintainability and testability:

- expose layers and prefabs through inspector fields instead of hard-coded values
- centralize input handling
- use reusable interaction interfaces for raycast targets
- add clear comments where the player flow depends on object hierarchy or scene setup
- add lightweight play mode tests around trigger and collection behavior
