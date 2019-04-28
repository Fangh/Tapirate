using UnityEngine;
using System;

[Serializable]
public struct SPirate
{
    public string name;
    public int salary;
    public int age;
    public string pet;
    public string instrument;
    public string[] skills;
    public string[] languages;
    public Color pictureColor;

    public SPirate(string _name, int _salary, int _age, Color _pictureColor)
    {
        name = _name;
        salary = _salary;
        age = _age;
        pet = "Parrot";
        skills = new string[]{ "Cook", "Fisherman"};
        instrument = "Flute";
        languages = new string[] { "english" };
        pictureColor = _pictureColor;
    }

    public SPirate(string _name, int _salary, int _age, string _pet, string _instrument, string[] _skills, string[] _languages, Color _pictureColor)
    {
        name = _name;
        salary = _salary;
        age = _age;
        pet = _pet;
        instrument = _instrument;
        skills = _skills;
        languages = _languages;
        pictureColor = _pictureColor;
    }
}