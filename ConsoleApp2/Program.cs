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
            return 0;
        case "*" or "/":
            return 1;
        default:
            return 2;
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
            while (operators.Count() > 0 && Precedence(operators.Peek()) >= Precedence(token))
            {
                if (operators.Peek() != "(")
                {
                    output.Push(operators.Pop());
                } else break;
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

    while (! (operators.Count() == 0))
    {
        output.Push(operators.Pop());
    }

    return output;
}

bool work = true;
while (work)
{
    string input = ReadExpr();
    ArrayList tokens = Tokenize(input);
    Queue rpnTokens = ToRPN(tokens);
    Console.WriteLine(LetsCount(rpnTokens));
    Console.Write("Continue?: ");
    if (Console.ReadLine() == "No")
    {
        work = false;
    }
}


string LetsCount(Queue notation)
 {
     Stack calculated = new Stack();

     while(notation.Count() > 0)
     {
         string token = notation.Pop();
         if (int.TryParse(token, out _))
         {
             calculated.Push(token);
         }
         else
         {
             var num2 = calculated.Pop();
             var num1 = calculated.Pop(); 
             calculated.Push(count(num1, num2, token));
         }
     }

     string result = calculated.Pop();
     return result;
 }

string count(string firstNum, string secondNum, string oper)
{
    double result = 0;
    switch (oper)
    {
        case "+":
            result = double.Parse(firstNum) + double.Parse(secondNum);
            break;
        case "-":
            result = double.Parse(firstNum) - double.Parse(secondNum);
            break;
        case "/":
            result = double.Parse(firstNum) / double.Parse(secondNum);
            break;
        case "*":
            result = double.Parse(firstNum) * double.Parse(secondNum);
            break;
        case "^":
            result = Math.Pow(double.Parse(firstNum), double.Parse(secondNum));
            break;
        default:
            throw new Exception("Illegal operation");
    }

    return result.ToString();
}
