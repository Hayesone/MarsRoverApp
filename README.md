# Mars Rover App
Trello used. https://trello.com/invite/b/XUxZ1l34/ATTIa006286cc4e61c0b8b6ad3367db57e8bACD5C101/marsroverapp
## Thought process

Break it down into an overview, look at the inputs and outputs to see what is needed.

## Overview

Rover lands on a **plateau** on Mars, it can **move** and **rotate**, through a list of **commands**.

The **plateau**, size is known before the Rover lands. When the rover moves it will need to know about the **plateau**.

For the app, inputs are given and the output is the final location of each Rover and their faced-direciton.

Expected input:

“X Y” Plateau upper right coords

“X Y Direction” Rover starting point and heading

“LMLMLMLMM” Rover movement commands

Expected output:

X Y Direction

X Y Direction

### Plateau

Initially plateau wasn't a class, but it became clear that in order to validate the moves of the Rover it needed to know where it is at, and by referencing the plateau object we can get this info. It seems to align with the idea of the Rover being on Mars and knowing its "operation area" or plateau that it can move around on.

### Rover

Rover handles the two commands rotate and move, with another function processing these actions one by one. By handling the move validation in Plateau, the rover only needs to check if its possible, and can make a move based off the validation returned.

### Handling inputs

There's some room for improvement here, the try catch seems like a cop out to avoid NULL and incorrect inputs; but for now it handles the input with the a noted messy behaviour belonging to PlateauInput() and RoverLandInput(). The two methods will take the input "X Y random inputs added on" and it works due to taking the first necessary indexs from the split string.

## Typical Tasks

- [x] Capture user input

- [x] Process / validate user input

- [x] Move rover

- [x] Rotate rover

- [x] Store position

- [x] Maintain plateau

- [x] Validate next move

- [x] Output position / status

## Additional features
- Prevent rovers moving/crashing into each other
- Prevent rover from fall off plateau
- Prevent rover from landing on another
- Prevent rover from landing outside of plateau
- Handle new input for poor landing location

## Improvments to be made
- Better input handling
- Cleaner error handling, maybe less recursive funtion calling
- Do more testing for each of the use cases