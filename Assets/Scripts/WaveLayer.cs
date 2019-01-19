using UnityEngine;

[HasSortingLayer("waveLayer")]
[ExecuteInEditMode]
public class WaveLayer : MonoBehaviour
{
    [SerializeField] private string waveLayer;
    private void OnEnable()
    {
        SpriteRenderer[] children = GetComponentsInChildren<SpriteRenderer>();
        for (int i = 0; i < children.Length; i++)
            children[i].sortingLayerName = waveLayer;
    }

}