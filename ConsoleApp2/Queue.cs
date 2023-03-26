﻿using System.Collections;

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

    public string Pop()
    {
        if (_last == 0)
        {
            Console.WriteLine("Queue is empty");
            return null;
        }
        else
        {
            string element = _array[0];
            for (int i = 0; i < _last - 1; i++)
            {
                _array[i] = _array[i + 1];
            }
            _last--;
            _array[_last] = null;
            return element;
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
