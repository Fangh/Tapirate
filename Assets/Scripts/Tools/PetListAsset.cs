using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "PetList", menuName = "ScriptableObjects/Pet List", order = 1)]
public class PetListAsset : ScriptableObject
{
    public List<string> pets;
}