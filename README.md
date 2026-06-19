# JamTemplate

This is a Unity Template for future games. 
Here we write __nice to haves__ in this templates for later development or creation

## NICE TO HAVES

### ART
We should aim to have generic art that we can use for quick prototyping, things like collision shapes for tiles and even an animated character to use in prototypes. 
> [!Note]
> All of this SHOULD change once we start working on a game of course!

- [ ] (WIP) Base tiles for platformer and Top down games. 
- [ ] Dummy character with basic animations states.
- [ ] Intro screen with credits.

### EDITOR
 - [X] Base template prefab for any object in game (so all follow the same architecture).
 - [X] Sound Library architercture.
 - [ ] Dummy base sound for "This object doesnt have any sound" so we know which sounds are missing. (to be recorded)
 - [X] Template Scenes.
 - [X] "Playground gameplay" scene and "Playground level design" scene.
 - [X] Grid prefab that is already set up with basic tilempaps added.
 - [ ] Conditional tiles for platformer and top down. (To Be researched)
 - [X] Basic settings UI that connects variables such as volume, music, sfx, etc to the UI.
 - [ ] Animation Framework. (An animator that has the basic animations that we use and animation tags).
 - [X] Generic Menu prefab.
     
 ### PROGRAMMING
  - [ ] Base State Machine.
    - [ ] Base platformer character controller.
    - [ ] Base Top Down character controller.
  - [X] Persisten data manager. (Done)
  - [X] Sounds Manager, so every object can call a "PlaySound()" method, even if the sound is empty.
  - [ ] Music Manager, with fade in and fade out transitions.
  - [ ] Transition manager (For scene/level change)
  - [ ] Debug events toggles.
  - [ ] Debug menu.
  - [ ] Animation Tags.

## Other NICE to HAVE that i don't really know where the place?
  - [ ] Basic Tutorial with base keys. (Like WASD movement and other action keys) 
