# Cows And Bulls
A a basic Cows and Bulls Windows desktop application using .NET WinForms.

The program allows the user to play against the computer and try to find it's guess.

The program first asks the user for the maximal number of guesses (The number of rows), that can be chosen by clicking on a specific button.
According to that chose, the program creats the beggining board that look as follows:
- 4 buttons in black color
- X rows of 4 buttons with no color, according to the number of guesses the user asked for
- To the right of each row there is an arrow button that the user can click on in order to submit his current guess
- A group of 4 buttons that show the result of each guess (black for choosing cuurect color in a currect position, yellow for currect color but not in the currect position)

![beggining stage board](https://user-images.githubusercontent.com/77329952/104428350-0eae8480-558d-11eb-8482-ab83848acb2e.jpg)

Then, the user can select color for a specific box by clicking on that box and checking one color out of the 8 that are given

![choosing color](https://user-images.githubusercontent.com/77329952/104429992-db6cf500-558e-11eb-9455-fb681a6299bc.jpg)

Only after selecting colors for all 4 boxes, the arrow button is available for clicking, and the result of the current guess is shown on the right. 

![black yellow](https://user-images.githubusercontent.com/77329952/104430120-f50e3c80-558e-11eb-89a4-67a79288f395.jpg)







The game is designed in a way that events are raised from the Logic Layer and handled in the UI layer in order to update the display.
