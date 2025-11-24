# C-Sharp Basic Assignment 2 - Calculator

 Your assignment is to create a basic Console-based calculator using C#. It should 
 be able to handle basic mathematical operations (addition, subtraction, multiplication,
 division), and be able to present the results in a consistent way.

## Required Features
  - The program should be able to perform basic mathematical operations (Math has 
  methods for more advanced operations if you include them). Addition, Subtraction, 
  Division, Multiplication, etc…
  - The program should keep running until the user chooses to end it. 

## Code Requirements
  - Each mathematical operation should be in its own method.
  - Addition and Subtraction should be able to handle any number of parameters
  - Use a loop and a menu system to keep the program running.

## My comments
The specification are a bit vague, but my implementation will handle addition, 
subtraction, multiplication and division. ex. a + b * c / d + e * f - g. 
I do not see any need for a variable number of parameters for the methods in 
my implementation. It could perhaps be useful in a simpler implementation where 
you only have one kind of operator at the time, ex. a - b - c - d.
A variable number of parameters could be implemented with the param keyword and 
an array.
