# LemonadeStand

My Lemonade Stand uses SOLID design principles by adhering to the:

Open/Closed Principle - All member variables and methods are set to the correct Access Level for their
use (short of using get/set properties). The only member variables or methods that are set to 'public' 
are called or used in another class.There are no 'protected' variables, classes, or methods because, as
the game is designed, there is no class inheritance.

Interface Segregation Principle - All methods in each class are necessary to the correct functioning of 
that class.  