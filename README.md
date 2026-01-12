Fruit Slot Machine (Unity)

Project Overview
The "Fruit Slot Machine" is a simple 2D slot machine game developed using "Unity" and "C#".  
The game simulates a classic casino-style fruit slot where reels spin and stop randomly to display fruit symbols.

This project focuses on "game logic, reel spinning, randomness, and basic UI interaction".

---

How the Game Works

1. The slot machine consists of "multiple reels", each containing fruit symbols.
2. When the "Spin" button is pressed:
   - All reels start spinning vertically.
   - Each reel spins at a defined speed.
3. After a short delay:
   - Reels stop one by one.
   - Symbols snap to predefined slot positions.
4. Final symbols are chosen "randomly".
5. Matching symbols determine the result (win / lose logic can be extended).

---

Core Concepts Used

- Unity GameObjects & Transforms  
- C# Scripting  
- Coroutines for reel spinning  
- Randomization using `Random.Range()`  
- Slot snapping logic  
- Unity 2D assets & materials  

---

Project Structure

FruitSlot/
├── Assets/
│ ├── Scripts/
│ │ ├── Reel.cs
│ │ ├── Slots.cs
│ ├── Scenes/
│ │ └── SampleScene.unity
│ ├── Materials/
│ └── Sprites/
├── Packages/
├── ProjectSettings/
└── README.md

How to Run the Project

1. Open "Unity Hub"
2. Click "Open Project"
3. Select the 'FruitSlot' folder
4. Open 'SampleScene'
5. Click "Play"

Gameplay Demo

[Gameplay Preview](media/FruitSlotMachine-SampleScene-Gif.mp4)



