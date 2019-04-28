using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "NameList", menuName = "ScriptableObjects/Name List", order = 1)]
public class NameListAsset : ScriptableObject
{
    public List<string> firstNames;
    public List<string> lastNames;
}