using System;

/// <summary>
/// A struct that represents a position on the grid.
/// </summary>
public struct GridPosition
{
    public readonly int x;
    public readonly int z;

    public GridPosition(int x, int z)
    {
        this.x = x;
        this.z = z;
    }

    public override readonly string ToString()
    {
        return $"({x}, {z})";
    }

    public static bool operator ==(GridPosition a, GridPosition b)
    {
        return a.x == b.x && a.z == b.z;
    }

    public static bool operator !=(GridPosition a, GridPosition b)
    {
        return !(a == b);
    }

    public static GridPosition operator +(GridPosition a, GridPosition b)
    {
        return new GridPosition(a.x + b.x, a.z + b.z);
    }

    public override bool Equals(object obj)
    {
        if (obj is GridPosition other)
        {
            return x == other.x && z == other.z;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(x, z);
    }
}