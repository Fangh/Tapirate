using UnityEngine;
using System;
using System.Threading.Tasks;

[AttributeUsage(AttributeTargets.Field, Inherited = true, AllowMultiple = true)]
public class ButtonAttribute : PropertyAttribute
{
    public string buttonLabel;
    public string method;

    // Set this false to make the button not work whilst in playmode
    public bool isActiveAtRuntime = true;
    // Set this to false to make the button not work when the game isnt running
    public bool isActiveInEditor = true;

    public ButtonAttribute(string buttonLabel, string method, int order = 1)
    {
        this.buttonLabel = buttonLabel;
        this.method = method;

        this.order = order; // Defualt the order to 1 so this can draw under headder attribles
    }
}