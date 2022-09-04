namespace Algorithms;

public class VirtualMemory
{
    private readonly int[] _data;

    public VirtualMemory()
    {
        _data = Enumerable.Repeat(-1, 128).ToArray(); // массив длинной 128 состоящий из -1
    }

    public int Alloc(int size)
    {
        var point = 1488;
        var freeSpace = 0;
        var realSize = size + 2;

        for (int i = 0; i < _data.Length; i++)
        {
            if (_data[i] == -2)
            {
                i = (i + 1) + _data[i + 1];
                freeSpace = 0;
            }
            else if (_data[i] == -1)
            {
                point = i;
                freeSpace += 1;
                if (freeSpace == realSize)
                {
                    _data[point - (realSize - 1)] = -2;
                    _data[(point + 1) - (realSize - 1)] = size;
                    return point + 1 - size;
                }
            }
        }
        throw new OutOfMemoryException();
    }



    public void Free(int point)
    {
        var offset = _data[point - 1] - 1;

        GuardPoint(point, offset);

        for (int i = point - 2; i < point + offset + 1; i++)
        {
            _data[i] = -1;
        }
    }

    public void SetData(int point, int offset, int value)
    {
        GuardPoint(point, offset);
        _data[point + offset] = value;
    }

    public int GetData(int point, int offset)
    {
        GuardPoint(point, offset);
        return _data[point + offset];
    }
    private void GuardPoint(int point, int offset)
    {
        if (_data[point - 2] != -2)
        {
            throw new IndexOutOfRangeException();
        }

        var maxOffset = _data[point - 1] - 1;

        if (offset > maxOffset)
        {
            throw new IndexOutOfRangeException();
        }
    }

    public void WriteLineDataConsole()
    {
        for (int i = 0; i < _data.Length; i++)
        {
            Console.Write(i);
            Console.Write('|');
            Console.WriteLine(_data[i]);

        }
    }
}
