using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "InstrumentList", menuName = "ScriptableObjects/Instrument List", order = 1)]
public class InstrumentListAsset : ScriptableObject
{
    public List<string> instruments;
}