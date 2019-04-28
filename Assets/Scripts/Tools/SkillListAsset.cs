using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "SkillList", menuName = "ScriptableObjects/Skill List", order = 1)]
public class SkillListAsset : ScriptableObject
{
    public List<string> skills;
}