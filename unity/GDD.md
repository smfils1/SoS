# Game Design Document

## Summary

Shoot or Survive is an open-source web game of survival. You're either the one shooting or the one running away. The choice is yours. This plug and play FPS web game is a battle between you and your enemies that require accuracy & speed. The ability to attack or avoid enemies with different controls leads to a unique web experience.

## Story

The game takes place on a stage, as seen in Figure 1. This stage is surrounded by fire, giving the game a battle vibe. There are two character types; player and the enemies. The player is fighting the forces that will push it to the pits of hell by any means necessary. The player can either go down fighting or running away. The enemies are the forces that don't tire out. They get stronger in numbers. As a result, the player has to do more than their best to try to stay alive.

## Mechanics

### Movement:

The player can move in the x & z-axis and rotate as shown in Figure #. If the up, down, left, and right arrow keys are pressed the player moves forward, backward, left, and right respectively at a constant speed. Alternatively, if the player chooses to use a gamepad, the player can use the left stick to move. The enemies can only move in the x & z-axis while chasing the player using unity's navmesh features. To look around, the player must rotate itself. More specifically, the player vision, which is the main camera, has to rotate around the y-axis to look around horizontally. To look vertically the player's vision has to move around the x-axis. Both movements are controlled by sensitivity. The player can rotate horizontally without any limits. However, there is some limitation to the player's ability to rotate vertically. The rotation must be clamped so the player can only look about 90 degrees about its line of sight either up or down, as shown in Figure #.

### Shooting:
Shooting is depend on the player's line of sight. As a result, the player has the ability to aim by turn horizontally along the x-axis or vertically along the y-axis. THese are the same controls for movement shown in figure #.  The line of sight of the player is represented by a crosshair that stays centered relative to the player's vision. To shoot the player have to left click if using a mouse or press R2 if using a gamepad which produces a physics raycast to determine what was hit. Each time the player shoots, a gunshot audio is played. Also the gun recoils by offseting the player line of sight. Once the player starts shooting then the enemy's health decreases if the produced raycast hits it. However, the player health also decrease if the enemy is close enough to attack. Players are only winning if they are alive. 

### Randomization:
As show in Figure 2, the stage will be a 50x50 square that will be divided into 4 quadrants when deciding where to spawn in enemies. The first step is to determine what quadrant the player is currently in as no enemies should spawn in that quadrant. Then a random quadrant is choosen from the remaining 3 which will then be the quadrant in which the enemy will spawn. Then a random x and z pair with their range being in the selected quadrant is generated and the enemy is initialized to that location.

### Progression:
The goal is to stay alive as long as possible. If player is killed or falls off stage, then they lose. However, as the levels increase, so will the overall dificulty of the game. At the start of each level, (the current level + 9) enemies will be evenly distributed into an array that will dictate at what time in the level they will spawn. The interval in which they spawn will range from 2 to 22 seconds in the level (each level being 30 seconds) with each enemy spawning every (20 / total number of enemies in this level) seconds. The damage the player does to an enemy will also increase as the level increases and is calculated using the formula (10 * ((level / 10) + 1)). 

## Dynamics: 
During gameplay, players are moved from the inscribed layer to the dynamic layer. Dynamics are the emergent behavior that arises when mechanics are put into use. The combination of the above mechanics emerges different survival strategies. As the levels increase in difficulty, player has to make a choice to either survive by killing the enemies or running away. This decision is also affected by how much time is left in the current level. If there are a lot of enemies and the level just started, the player may choice to attack. However, if there is little time left, the player may choose to avoid enemies to be saved by starting a new level. 


## UI & Aesthetics

As shown in Figure 2, the character & enemies are designed with simplicity in mind. This allows us to focus on the mechanics that will make an exciting game. Both the enemies & player are just colored capsules. To signal danger, the enemy is red. The same ideas are applied to the menu UX. The transitions between different scenes in the game are so simple that it makes navigation intuitive. The start scene is the main menu that has four buttons; play, settings, controls, and about. Play will transition the player to the gameplay. If game controls haven't been set up, the default control is the keyboard. However, in the settings, there is also the option to change to a gamepad and controller sensitivity. As one is playing the game, if the player is killed, the game ends with a game-over menu that has three buttons; retry, main menu, and exit. Retry will restart the game. Main menu will redirect one to the starting menu. Controls will show player controls. Lastly, the exit button will close the game.


## Figures

![drawing](https://i.imgur.com/qnyP7O2.png)
![drawing](https://i.imgur.com/oJuMwzn.png)
![drawing](https://i.imgur.com/zkVP1iN.png)


