using System;

[Serializable]
public struct SMinMax
{
    public float min;
    public float max;

    public SMinMax(float _min, float _max)
    {
        min = _min;
        max = _max;
    }
}