
#### ADVANCED EXERCISE: Advanced Dictionary Operations

WARNING! ONLY FOR ADVANCED PROGRAMMERS.

The Exercises marked as “ADVANCED” are meant to be challenging exercises for those that want to really put their knowledge to the test. They are exceptionally hard to complete in continuous way, so if you see yourself getting stuck and being confused on how to continue, do not worry! You have 2 options here:

Either FAIL 3 times for the Solution Explanation to unlock, there you will get our solution to the exercise which you can just copy/paste in to complete the exercise.

Or you leave the exercise incomplete and try them again later in the course, once you consider yourself advanced enough to complete the exercise.

Other than that, Good Luck with the exercise!

####################################### Advanced Dictionary Operations

Please, avoid changing the given source code for the exercise!

Only add code, don’t modify unless it is instructed to do so.

Task

Create a C# program that declares a dictionary where the key is a string and the value is a custom object. The program should:

    1. Define a class Student with properties Id, Name, and Grade.

        - To be robust across graders that treat warnings as errors, initialize Name to string.Empty (i.e., public string Name { get; set; } = string.Empty;).

    2. Initialize a dictionary with keys as student names and values as Student objects.

    3. Add at least three Student objects to the dictionary.

    4. Iterate through the dictionary and print each student’s details from the object (use student.Name, not the dictionary key).

    5. Print exactly the following three lines, in this order:
```markdown
Name: John, Id: 1, Grade: 85
Name: Alice, Id: 2, Grade: 90
Name: Bob, Id: 3, Grade: 78
```
#### Notes:
• Use Console.WriteLine and ensure you print Name, Id, and Grade from the Student object so the output matches the expected lines exactly.
• The provided unit test captures console output and compares it exactly, including line breaks.

The "Solution Explanation" tab above will unlock on the third failed attempt. There you should find our solution to this exercise. However, try to solve it yourself first!

We have faith in you 💕