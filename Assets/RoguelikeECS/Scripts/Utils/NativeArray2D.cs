using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Mathematics;

public struct NativeArray2D<T> : IEnumerable<T>, System.IDisposable where T : struct
{
    public readonly int N, M;
    private NativeArray<T> array;
    public readonly int2 gridOrigin;

    public NativeArray2D(int N, int M, 
        int2 gridOrigin = default(int2), 
        Allocator allocator = Allocator.Persistent)
    {
        this.N = N;
        this.M = M;
        this.gridOrigin = gridOrigin;
        
        array = new NativeArray<T>(N * M, allocator);
    }

    public NativeArray<T> FlattenArray
    {
        get
        {
            return array;
        }
    }

    public int TotalSize
    {
        get
        {
            return array.Length;
        }
    }

    public T this[int2 pos]
    {
        get
        {
            return this[pos.x, pos.y];
        }
        set
        {
            this[pos.x, pos.y] = value;
        }
    }

    public T this[int x, int y]
    {
        get
        {
            var index = (x - gridOrigin.x) + (y - gridOrigin.y) * N;
            return array[index];
        }
        set
        {
            var index = (x - gridOrigin.x) + (y - gridOrigin.y) * N;
            array[index] = value ;
        }
    }

    public int2 IndexToPos(int index)
    {
        int x = index % N - gridOrigin.x;
        int y = (index - x) / N - gridOrigin.y;

        return new int2(x, y);
    }

    public void Dispose()
    {
        array.Dispose();
    }

    public bool InBounds(int2 pos)
    {
        return InBounds(pos.x, pos.y);
    }
    public bool InBounds(int x, int y)
    {
        return (x >= gridOrigin.x && x < gridOrigin.x + N 
                                  && y >= gridOrigin.y && y < gridOrigin.y + M);
    }
    
    public IEnumerator<T> GetEnumerator()
    {
        return array.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
