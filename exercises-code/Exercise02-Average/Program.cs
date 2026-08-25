// Coding Exercise 2: Fixing Simple Bugs
// Correctly calculate and display the average of three numbers.
// Expected console output: The average is: 20

int firstNumber = 10;
int secondNumber = 20;
int thirdNumber = 30;

// Cast to double so the division is floating-point, not integer truncation.
double average = (firstNumber + secondNumber + thirdNumber) / 3.0;

Console.WriteLine($"The average is: {average}");
