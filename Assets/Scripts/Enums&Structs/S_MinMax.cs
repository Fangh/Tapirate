using System;

[Serializable]
public struct S_MinMax
{
    public float min;
    public float max;

    public S_MinMax(float _min, float _max)
    {
        min = _min;
        max = _max;
    }
}