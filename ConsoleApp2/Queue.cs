namespace ConsoleApp2;

public class Queue
{
    private string[] _array = new String[10];
    private int _last = 0;

    public void Push(string element)
    {
        _array[_last] = element;
        _last++;

        if (_last == _array.Length)
        {
            var extendedArray = new String[_array.Length * 2];
            for (var i = 0; i < _array.Length; i++)
            {
                extendedArray[i] = _array[i];
            }

            _array = extendedArray;
        }
    }

    public void Pop()
    {
        if (_last == 0)
        {
            Console.WriteLine("Queue is empty");
            return;
        }
        else
        {
            for (int i = 0; i < _last - 1; i++)
            {
                _array[i] = _array[i + 1];
            }

            _array[_last] = null;
            _last--;
        }

    }

    public string Peek()
    {
        return _array[0];
    }

    public int Count()
    {
        return _last;
    }
}
