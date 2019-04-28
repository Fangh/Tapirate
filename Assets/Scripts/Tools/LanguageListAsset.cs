using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "LanguageList", menuName = "ScriptableObjects/Language List", order = 1)]
public class LanguageListAsset : ScriptableObject
{
    public List<string> languages;
}