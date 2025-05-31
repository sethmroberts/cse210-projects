
using System.Diagnostics;
using System.Xml.Schema;

/// <summary>
/// Represents a fraction with a numerator and denominator
/// This is more accurate than storing a double.
/// </summary>
public class Fraction
{
    private int _numer;
    private int _denom;

    public Fraction()
    {
        _numer = 1;
        _denom = 1;
    }

    public Fraction(int whole)
    {
        _numer = whole;
        _denom = 1;
    }

    public Fraction(int numer, int denom)
    {
        _numer = numer;
        _denom = denom;
    }

    public string GetFractionString()
    {
        string result = $"{_numer} / {_denom}";
        return result;

    }

    public double GetDecimalValue()
    {
        double result = (double)_numer / (double)_denom;
        return result;
    }
}