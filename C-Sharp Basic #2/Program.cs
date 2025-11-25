using System.Text.RegularExpressions;
using static System.Console;

// Local functions
// I don't really need the functions to be able to take a variable number of parameters, but it's in the specification.
double Add(params double[] values)
{
    double result = values[0];

    for (int i = 1; i < values.Length; i++)
    {
        result += values[i];
    }

    return result;
}


double Sub(params double[] values)
{
    double result = values[0];

    for (int i = 1; i < values.Length; i++)
    {
        result -= values[i];
    }

    return result;
}


double Mul(params double[] values)
{
    double result = values[0];

    for(int i = 1; i < values.Length; i++)
    {
        result *= values[i];
    }

    return result;
}


double Div(params double[] values)
{
    double result = values[0];

    for (int i = 1; i < values.Length; i++)
    {
        if (values[i] == 0) throw new Exception("Division by Zero");
        result /= values[i];
    }

    return result;
}



// Main program
string input;
string regexPattern = "([+*/-])";
List<string> tokens;
List<string> temp;
double result = 0;


WriteLine("Exit the calculator by typing \"exit\"");

while (true)
{
    // Input
    Write("Input: ");
    input = ReadLine()!;

    if (input!.ToLower() == "exit") break;

    try
    {
        // Separate into tokens
        tokens = new(Regex.Split(input, regexPattern));


        // Negative numbers are a problem and will cause the Regex.Split() to insert some empty strings
        // Removing theses empty strings and trimming any whitespace
        temp = new List<string>();

        foreach(string token in tokens)
        {
            if (token == "") continue;
            else temp.Add(token.Trim());
        }

        tokens = new(temp);


        // The tokens can only be +,-,*,/ or a number. If something else occurs, throw an exception
        foreach(string token in tokens)
        {
            switch(token)
            {
                case "+":
                case "-":
                case "*":
                case "/":
                    break;
                default:
                    if (!double.TryParse(token, out _))
                    {
                        throw new Exception($"The expression cannot contain \"{token}\"");
                    }
                    break;
            }
        }


        // Removing extra negative signs and adding them to the following number
        temp = new();

        int start;  // Will be the position of the first operator

        if (tokens[0] == "-" && tokens[1] == "-")
        {
            temp.Add(tokens[2]);
            start = 3;
        }
        else if (tokens[0] == "-")
        {
            temp.Add("-" + tokens[1]);
            start = 2;
        }
        else
        {
            temp.Add(tokens[0]);
            start = 1;
        }


        for (int i = start; i < tokens.Count - 1;)      // It will jump from operator to operator
        {
            if (tokens[i+1] == "-")
            {
                temp.Add(tokens[i]);
                temp.Add("-" + tokens[i + 2]);
                i += 3;
            }
            else
            {
                temp.Add(tokens[i]);
                temp.Add(tokens[i + 1]);
                i += 2;
            }
        }

        tokens = new(temp);


        // Resolving multiplication and division
        temp = new();  

        temp.Add(tokens[0]);

        for (int i = 1; i < tokens.Count - 1; i += 2)
        {
            switch (tokens[i])
            {
                case "+":
                case "-":
                    temp.Add(tokens[i]);
                    temp.Add(tokens[i + 1]);
                    break;
                case "*":
                    temp[temp.Count - 1] = Convert.ToString(Mul(double.Parse(temp[temp.Count - 1]), double.Parse(tokens[i + 1])));
                    break;
                case "/":
                    temp[temp.Count - 1] = Convert.ToString(Div(double.Parse(temp[temp.Count - 1]), double.Parse(tokens[i + 1])));
                    break;
            }
        }

        tokens = new(temp);


        // Calculating the final result
        result = double.Parse(tokens[0]);

        for (int i = 1; i < tokens.Count - 1; i += 2)
        {
            switch (tokens[i])
            {
                case "+":
                    result = Add(result, double.Parse(tokens[i + 1]));
                    break;
                case "-":
                    result = Sub(result, double.Parse(tokens[i + 1]));
                    break;
            }
        }

        // The result
        WriteLine($"Result: {result}\n");
    }
    catch(Exception e)
    {
        WriteLine($"\n{e.Message} Please try again!\n");
    }
}

