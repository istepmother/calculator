// namespace ConsoleApp2;

using ConsoleApp2;
using static ConsoleApp2.ArrayList;

string ReadExpr()
{
    Console.Write("Enter the math expression: ");
    return Console.ReadLine()!;
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


Queue queue = new Queue();
queue.Push("324");
queue.Push("+8762-78/5");
queue.Push("69");
Console.WriteLine(queue.Peek());
Console.WriteLine("hey man Il uv Taras");

// // Main
//
// string input = ReadExpr();
// ArrayList tokens = Tokenize(input);
//
// // Console.WriteLine(string.Join("|", tokens));
// for (int index = 0; index < tokens.Count(); index++)
// {
//     Console.WriteLine(tokens.GetAt(index));
// }