using ConsoleApp2;

string ReadExpr()
{
    Console.Write("Enter the math expression: ");
    return Console.ReadLine()!;
}

bool IsOperator(string token)
{
    if (token.Equals("+") || token.Equals("-") || token.Equals("*") ||
        token.Equals("/") || token.Equals("^"))
    {
        return true;
    }

    return false;
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
        
        else if (IsOperator(s.ToString()) || s.Equals('(') || s.Equals(')'))
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

Queue ToRPN(ArrayList tokens)
{
    Queue output = new Queue();
    Stack operators = new Stack();
    foreach (string token in tokens)
    {
        if (int.TryParse(token, out _)) {output.Push(token);}
        else if (IsOperator(token))
        {
            while (operators.Count() > 0 && operators.Peek() != "(" && 
                   (Precedence(operators.Peek()) > Precedence(token)|| 
                    Precedence(operators.Peek()) == Precedence(token)))
            {
                output.Push(operators.Pop());
            }
            operators.Push(token);
        }
        else if (token.Equals("("))
        {
            operators.Push(token);
        }
        else if (token.Equals(")"))
        {
            while (operators.Count() > 0 && operators.Peek() != "(")
            {
                output.Push(operators.Pop());
            }
            operators.Pop();
        }

    }

    return output;
}


string input = ReadExpr();
ArrayList tokens = Tokenize(input);
Console.WriteLine(string.Join("|", tokens));
Queue rpnTokens = ToRPN(tokens);
while(rpnTokens.Count() > 0) {Console.WriteLine(rpnTokens.Pop());}
