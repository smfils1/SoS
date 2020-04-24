![Unity Build](https://github.com/smfils1/SoS/workflows/Unity%20Build/badge.svg)
# [Demo](https://smfils1.github.io/SoS/)

## Running Locally

```bash
git clone https://github.com/smfils1/SoS # or clone your own fork
```
Open project using UnityHub or Unity. The project is being developed in Unity 2019.3.1f1

## CI/CD

We using Github Actions & Github Pages to build & deploy [SoS](https://smfils1.github.io/SoS-Website/)

![drawing](https://i.imgur.com/6BNS8mS.png)


# Game Design Document

## Summary

Shoot or Survive is an open-source web game of survival. You're either the one shooting or the one running away. The choice is yours. This plug and play FPS web game is a battle between you and your enemies that require accuracy & speed. The ability to attack or avoid enemies with different controls leads to a unique web experience.

## Story

The game takes place on a stage, as seen in Figure 1. This stage is surrounded by fire, giving the game a battle vibe. There are two character types; player and the enemies. The player is fighting the forces that will push it to the pits of hell by any means necessary. The player can either go down fighting or running away. The enemies are the forces that don't tire out. They get stronger in numbers. As a result, the player has to do more than their best to try to stay alive.

## Mechanics


### Scoring:


### Movement:

The player can move in the x & z-axis and rotate as shown in Figure #. If the up, down, left, and right arrow keys are pressed the player moves forward, backward, left, and right respectively at a constant speed. Alternatively, if the player chooses to use a gamepad, the player can use the left stick to move. The enemies can only move in the x & z-axis while chasing the player. To look around, the player must rotate itself. More specifically, the player vision, which is the main camera, has to rotate around the y-axis to look around horizontally. To look vertically the player's vision has to move around the x-axis. Both movements are controlled by sensitivity. The player can rotate horizontally without any limits. However, there is some limitation to the player's ability to rotate vertically. The rotation must be clamped so the player can only look about 90 degrees about its line of vision either up or down, as shown in Figure #.

### Shooting:

### Randomization:


### Progression:


## Dynamics


## UI & Aesthetics

As shown in Figure 2, the character & enemies are designed with simplicity in mind. This allows us to focus on the mechanics that will make an exciting game. Both the enemies & player are just colored capsules. To signal danger, the enemy is red. The same ideas are applied to the menu UX. The transitions between different scenes in the game are so simple that it makes navigation intuitive. The start scene is the main menu that has three buttons; play, settings, and about. Play will transition the player to the gameplay. If game controls haven't been set up, the default control is the keyboard. However, in the settings, there is also the option to change to a gamepad and controller sensitivity. As one is playing the game, if the player is killed, the game ends with a game-over menu that has three buttons; retry, main menu, and exit. Retry will restart the game. Main menu will redirect one to the starting menu. Lastly, the exit button will close the game.


## Figures

![drawing](https://i.imgur.com/qnyP7O2.png)
![drawing](https://i.imgur.com/oJuMwzn.png)
![drawing](https://i.imgur.com/zkVP1iN.png)


