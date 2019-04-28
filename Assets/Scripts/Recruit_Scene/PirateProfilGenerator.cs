using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PirateProfilGenerator : MonoBehaviour
{
    [SerializeField] private int numberToGenerate;
    [SerializeField] private GameObject cardPrefab;
    [SerializeField] private Transform picturePos;
    [SerializeField] private NameListAsset nameList;
    [SerializeField] private TextMeshProUGUI nameTextMesh;

    private Stack<GameObject> pirateCards = new Stack<GameObject>();
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
            SPirate pirate = new SPirate(CreateRandomName(), 12, 50);
            pirateCards.Push(Instantiate(cardPrefab, picturePos));
        }
        currentPicture = pirateCards.Peek();
    }

    void NextPirate()
    {
        currentPicture = pirateCards.Pop();
        currentPicture = pirateCards.Peek();
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