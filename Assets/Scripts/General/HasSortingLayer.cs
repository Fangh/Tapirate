using System;

[AttributeUsage(AttributeTargets.Class, Inherited = true)]
public class HasSortingLayer : Attribute
{
    string[] _names;
    public string[] Names { get { return _names; } }
    public HasSortingLayer(params string[] names) { _names = names; }
}