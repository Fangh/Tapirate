using UnityEngine;
using System;

[Serializable]
public struct SPirate
{
    public string name;
    public int salary;
    public int age;
    public bool petOwner;
    public string[] skills;
    public string instrument;
    public string[] languages;
    public Color pictureColor;

    public SPirate(string _name, int _salary, int _age)
    {
        name = _name;
        salary = _salary;
        age = _age;
        petOwner = false;
        skills = new string[]{ "a", "b"};
        instrument = "lol";
        languages = new string[] { "a" };
        pictureColor = UnityEngine.Random.ColorHSV();
    }
}