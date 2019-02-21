using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PirateProfilGenerator : MonoBehaviour
{
    [SerializeField] private int numberToGenerate;
    [SerializeField] private GameObject picturePrefab;
    [SerializeField] private Transform picturePos;
    [SerializeField] private NameListAsset nameList;
    [SerializeField] private TextMeshProUGUI nameTextMesh;

    // Start is called before the first frame update
    [ContextMenu("ChangeName")]
    void Start()
    {
        nameTextMesh.text = string.Format("{0} {1}", nameList.firstNames[Random.Range(0, nameList.firstNames.Count - 1)], nameList.lastNames[Random.Range(0, nameList.lastNames.Count - 1)]);

        for(int i = 0; i < numberToGenerate; i++)
        {
            Instantiate(picturePrefab, picturePos);
        }
    }
}