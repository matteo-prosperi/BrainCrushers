#region Using statements
using System;
#endregion

namespace BrainCrushers;

#region Intro
public class Matrix : IEquatable<Matrix>
{
    private readonly double[,] data;

    public Matrix(double n11, double n12, double n13, double n21, double n22, double n23, double n31, double n32, double n33)
    {
        data = new double[,] {
            { n11, n12, n13},
            { n21, n22, n23},
            { n31, n32, n33} };
    }

    public ref double this[int row, int column] => ref data[row, column];

    public static Matrix Zero() => new(0, 0, 0,
                                0, 0, 0,
                                0, 0, 0);

    public static Matrix Identity() => new(1, 0, 0,
                                    0, 1, 0,
                                    0, 0, 1);

    public static Matrix operator *(double a, Matrix b) => new Matrix(
        a * b[0, 0], a * b[0, 1], a * b[0, 2],
        a * b[1, 0], a * b[1, 1], a * b[1, 2],
        a * b[2, 0], a * b[2, 1], a * b[2, 2]);

#endregion
#region Addition Intro
    public static Matrix operator +(Matrix a, Matrix b)
    {
#endregion
#region Addition
        return null; //Fix me
#endregion
#region Addition Outro
    }

#endregion
#region Subtraction Intro
    public static Matrix operator -(Matrix a, Matrix b)
    {
#endregion
#region Subtraction
        return null; //Fix me
#endregion
#region Subtraction Outro
    }

#endregion
#region Multiplication Intro
    public static Matrix operator *(Matrix a, Matrix b)
    {
#endregion
#region Multiplication
        return null; //Fix me
#endregion
#region Multiplication Outro
    }

#endregion
#region Matrix-Vector Multiplication Intro
    public static double[] operator *(Matrix a, double[] b)
    {
        if (b is null)
            throw new ArgumentNullException(nameof(b));
        if (b.Length != 3)
            throw new ArgumentException(nameof(b));

#endregion
#region Matrix-Vector Multiplication
        return null; //Fix me
#endregion
#region Matrix-Vector Multiplication Outro
    }
#endregion
#region Outro
    public static bool operator ==(Matrix? a, Matrix? b)
    {
        if (a is null && b is null)
            return true;
        if (a is null ^ b is null)
            return false;

        for (int row = 0; row < 3; row++)
            for (int column = 0; column < 3; column++)
                if (a[row, column] != b[row, column])
                    return false;

        return true;
    }

    public static bool operator !=(Matrix? a, Matrix? b) => !(a == b);

    public bool Equals(Matrix? other) => this == other;

    public override bool Equals(object? obj) => obj is Matrix m ? Equals(m) : false;

    public override int GetHashCode()
    {
        HashCode hc = default;
        foreach(double n in data)
        {
            hc.Add(n);
        }
        return hc.ToHashCode();
    }
}
#endregion
