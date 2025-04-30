# Overgrown - 2D Co-Op Top-Down Game

**Overgrown** is a 2D top-down cooperative game built in Unity. Two players fight off waves of radioactive enemies that deal heavy damage when nearby. The players **share a single health bar**, making teamwork and positioning critical to survival.

---

## Table of Contents

- [Overview](#overview)
- [Controls](#controls)
- [How to Play](#how-to-play)
- [Features](#features)
- [Installation & Setup](#installation--setup)
- [Design & Planning](#design--planning)
- [Sprints](#sprints)
  - [Sprint 1](#sprint-1)
  - [Sprint 2](#sprint-2)
- [Kanban](#kanban)
- [Team Contributions](#team-contributions)

---

## Overview

Overgrown is designed for local co-op play. Players use keyboard controls to defeat increasingly difficult enemy waves. Survive as long as possible and master both melee weapons—sword and hammer—to strategically push back and stun enemies.

---

## Controls

| Player | Action            | Key(s)      |
|--------|-------------------|-------------|
| 1      | Move              | W A S D     |
| 1      | Attack            | Q (Sword) / E (Hammer) |
| 2      | Move              | I J K L     |
| 2      | Attack            | U (Sword) / O (Hammer) |
| Both   | Mute / Unmute     | M           |
| UI     | Navigate Menus    | Mouse       |

> **Note:** The game is best played with two people on one keyboard.

---

## How to Play

- Choose between **sword** (faster, less damage) or **hammer** (slower, more damage, can stun).
- Survive waves of enemies that **home in** on the nearest player.
- Keep an eye on the **shared health bar**—if one player takes too much damage, both lose.
- Navigate through the **main menu** to start the game or access options.

---

## Features

- 🔪 Two distinct melee weapons with unique effects (hammer stuns, sword is quick).
- 👥 Two-player simultaneous co-op using the same keyboard.
- ☣️ Enemies dynamically follow players and increase in difficulty per wave.
- 🔊 Mute option for gameplay audio.
- 🎨 Custom animated sprites by Erin.
- 🎮 Menu UI with scene transitions, options menu, and controls info.
- 🧠 Basic enemy AI that tracks and chases players.

---

## Installation & Setup

1. Clone the repo:
   ```bash
   git clone https://github.com/YOUR-USERNAME/2DGame.git
2. Open the project in Unity
3. Press Play in the Unity Editor to start the game

## Design
UML : https://drive.google.com/file/d/1ncaVr--bm-6ZlyibmiD9ZZYybruYmCEM/view?usp=sharing
Trello Board: https://trello.com/b/cIPeSPxo/cs345-trello-dev6

## Sprints

### Sprint 1

### Sprint 2
Review doc: https://docs.google.com/document/d/1TONnDUjtv5yFl8jSOo2wNyt_QlUEoWZvD6t3tHA47vY/edit?usp=sharing 
The goal of this sprint was to combine our individual work to demonstrate starting the game. 
Integrating player movement into the UI in place was crucial.
retrospective: https://docs.google.com/document/d/1B2oLj7do2nMbk6ZOLBaE8mjv9HcX_RO7l-6ViINlZpM/edit?usp=sharing 

## Kanban

## Contributions
- Lukas: Weapon Class and Enemy Class, Player Health.
- Erin: Player Movement and Custom Animations
- Kat: Menu UI, Health Bar, and other Player UI. (This includes transitions between different scenes)
- Ben: Hitboxes and Enemy Class stuff. Also GitHub researcher and troubleshooter
