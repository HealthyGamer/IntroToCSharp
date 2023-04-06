# Project Plan

Before starting a new project, it's always a good idea to have some idea of what you want to do.

Concept: Garden themed game inspired by the classic Lemonade Stand game.

## Version 1

The player controlls a single plant. Each day they can choose to grow or wait. Each option consumes water and energy, with growing taking more resources. Each day there will also be some kind of weather (sunny, cloudy, or rainy), which grants resources. Once the player has successfully chosen the grow option 10 times without running out of resources, they get the option to bloom and win the game.

### Features

- Intro text to explain the game and how to play.
- A simple game loop that allows the game to continue until it is won or lost.
  - Each day, print a status message and allow the user to choose an action.
  - After the player chooses an option, apply the results of the choice and the random weather event.
  - Determine whether the game is won or lost. If so, inform the player. If not, start the loop over again.

## Version 2

The next iteration could have mutliple different features. Each of these would have several steps for you to plan out and implement.

- A garden where the player can control multiple plants.
- Adding different types of plants that each have a different difficulty to win.
- More types of weather or options for the player.
- Add a UI with something like Windows Forms.
