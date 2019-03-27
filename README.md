# Space-Invaders
Game of Space Invaders created in C# as part of the SE456 Architecture of Real-Time Systems class at DePaul University during the Winter 2019 term. For this project I was tasked with recreating the original arcade game as much as I possibly could. I used a total of 10 design patterns throughout the development process.

Those 10 patterns are:

1. Singleton - To centralize the various manager and keep game score
2. Command - Set Time Events to perform animation and alien movement
3. Factory - Create 55 Aliens and the 4 Shields
4. Composite - Group the Aliens in a hierarchy, set them in a Alien Grid
5. Visitor - Detects collision for two game objects, delegates the action to the Observers
6. Observer - Fires off when listener is notified of a collision to perform the needed action.
7. Iterator - Walk through the various Linked Lists in the program to get the desired data I want
8. Proxy - Provided a placeholder for Game Sprites to make specific modifications
9. State - Various ship states and game cycling modes
10. Strategy - Used on Alien bombs to define different animations for each individual bomb.
