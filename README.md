# Cows And Bulls
A a basic Cows and Bulls Windows desktop application using .NET WinForms.

The program allows the user to play against the computer and try to find it's guess.

The program first asks the user for the maximal number of guesses (The number of rows), that can be chosen by clicking on a specific button.
According to that chose, the program creats the beggining board that look as follows:
- 4 buttons in black color
- X rows of 4 buttons with no color, according to the number of guesses the user asked for
- To the right of each row there is a button that the user can click on in order to submit his current guess
- A group of 4 buttons that show the result of each guess







The game is designed in a way that events are raised from the Logic Layer and handled in the UI layer in order to update the display.

Screenshots

Beggining stage of the board
