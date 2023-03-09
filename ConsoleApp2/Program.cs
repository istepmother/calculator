using ConsoleApp2;

string ReadExpr()
{
    Console.Write("Enter the math expression: ");
    return Console.ReadLine()!;
}

bool IsOperator(char token)
{
    if (s == '+' || s == '-' || s == '*' || s == '/' || s == '^' || s == '(' || s == ')')
}

ArrayList Tokenize(string expression)
{
    string buffer = "";
    ArrayList result = new ArrayList();

    foreach (char s in expression)
    {
        if (Char.IsNumber(s))
        {
            buffer += s;
        }
        
        else if (s == '+' || s == '-' || s == '*' || s == '/' || s == '^' || s == '(' || s == ')')
        {
            if (buffer.Length > 0)
            {
                result.Add(buffer);
                buffer = "";
            }
            result.Add(s.ToString());
        }
    }
    if (buffer.Length > 0)
    {
        result.Add(buffer);
    }
    return result;
}

int Precedence(string token)
{
    switch (token)
    {
        case "-" or "+":
            return 2;
        case "*" or "/":
            return 3;
        case "^":
            return 4;
        default:
            return 0;
    }
}

ArrayList ToRPN(ArrayList tokens)
{
    int number;
    Queue output = new Queue();
    foreach (string token in tokens)
    {
        if (int.TryParse(token, out number)) {output.Push(token);}
        else
        {
            
        }
    }

    return tokens;
}


string input = ReadExpr();
ArrayList tokens = Tokenize(input);
Console.WriteLine(string.Join("|", tokens));
ArrayList rpnTokens = ToRPN(tokens);
