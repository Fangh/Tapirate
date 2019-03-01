using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PirateProfilGenerator : MonoBehaviour
{
    [SerializeField] private int numberToGenerate;
    [SerializeField] private GameObject picturePrefab;
    [SerializeField] private Transform picturePos;
    [SerializeField] private NameListAsset nameList;
    [SerializeField] private TextMeshProUGUI nameTextMesh;

    private Stack<GameObject> piratePictures = new Stack<GameObject>();
    private GameObject currentPicture = null;
    // Start is called before the first frame update
    void Awake()
    {
        EventManager.Bind("PirateDiscarded", NextPirate);
    }

    void Start()
    {
        for(int i = 0; i < numberToGenerate; i++)
        {
            S_PirateData pirate = new S_PirateData(CreateRandomName(), 12, 50);
            piratePictures.Push(Instantiate(picturePrefab, picturePos));
        }
        currentPicture = piratePictures.Peek();
    }

    void NextPirate()
    {
        currentPicture = piratePictures.Pop();
        currentPicture = piratePictures.Peek();
        SetRandomColor();
        nameTextMesh.text = CreateRandomName();
    }

    string CreateRandomName()
    {
        return string.Format("{0} {1}", nameList.firstNames[Random.Range(0, nameList.firstNames.Count - 1)], nameList.lastNames[Random.Range(0, nameList.lastNames.Count - 1)]);
    }

    void SetRandomColor()
    {
        currentPicture.GetComponentInChildren<Image>().color = Random.ColorHSV();
    }
}