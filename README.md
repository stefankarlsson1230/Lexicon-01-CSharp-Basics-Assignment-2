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

## My Comments
I probably overworked this assignment, even though ChatGPT still can find some troublesome
edgecases (e.g. serveral operators in a row, or spaces in odd places), but I am content with my code.

* It works for addition, subtraction, multiplication and division in any order and for any 
  number of operands.
* I use Regex.Split() to create a list of tokens from the original input expression.
* This token-list is cleaned of empty strings, whitespaces and corrected for negative numbers.
* I perfom all multiplications and divisions before I finally calculate the final result by
  completing additions and subtractions.
* Most of the code is contined within a try-catch block, so any exceptions will just show the type 
  of error and give the user another try. I do throw a couple of exceptions:
	* Division by zero
	* If the expression contains anything beside +,-,*,/ or numbers.
