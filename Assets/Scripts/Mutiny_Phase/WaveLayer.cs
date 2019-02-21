using System.Threading.Tasks;
using UnityEngine;

[HasSortingLayer("waveLayer")]
[ExecuteInEditMode]
public class WaveLayer : MonoBehaviour
{
    [Button("Change Layer", "ChangeLayer", 1, isActiveInEditor = true)]
    [SerializeField] private string waveLayer;

    public void ChangeLayer()
    {
        SpriteRenderer[] children = GetComponentsInChildren<SpriteRenderer>();
        for (int i = 0; i < children.Length; i++)
            children[i].sortingLayerName = waveLayer;
    }

}