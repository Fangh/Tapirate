using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PirateProfilGenerator : MonoBehaviour
{

    [Header("Texts References")]
    [SerializeField] private TextMeshProUGUI TMP_profilName;
    [SerializeField] private TextMeshProUGUI TMP_profilSalary;
    [SerializeField] private TextMeshProUGUI TMP_profilAge;
    [SerializeField] private TextMeshProUGUI TMP_profilPet;
    [SerializeField] private TextMeshProUGUI TMP_profilSkills;
    [SerializeField] private TextMeshProUGUI TMP_profilInstrument;
    [SerializeField] private TextMeshProUGUI TMP_profilLanguages;

    [Header("Lists References")]
    [SerializeField] private InstrumentListAsset instrumentList;
    [SerializeField] private LanguageListAsset languageList;
    [SerializeField] private NameListAsset nameList;
    [SerializeField] private PetListAsset petList;
    [SerializeField] private SkillListAsset skillList;

    [Header("Other References")]
    [SerializeField] private GameObject cardPrefab;
    [SerializeField] private Transform picturePos;


    [Header("Settings")]
    [SerializeField] private int numberToGenerate;

    private Stack<SPirate> pirateProfils = new Stack<SPirate>();
    private GameObject displayedCard = null;
    private SPirate currentProfil = new SPirate();


    void Awake()
    {
        EventManager.Bind("PirateDiscarded", NextPirate);
    }

    void Start()
    {
        displayedCard = Instantiate(cardPrefab, picturePos);

        for (int i = 0; i < numberToGenerate; i++)
        {
            SPirate pirateData = CreateRandomPirate();
            pirateProfils.Push(pirateData);
        }
        currentProfil = pirateProfils.Peek();
        DisplayProfil(currentProfil);
    }

    /// <summary>
    /// Called by Event("PirateDiscarded")
    /// </summary>
    void NextPirate()
    {
        if(pirateProfils.Count > 0)
        {
            displayedCard = Instantiate(cardPrefab, picturePos);
            DisplayProfil(pirateProfils.Pop());
        }
        else
        {
            Debug.Log("THERE IS NO MORE PIRATE TO RECRUIT");
        }
    }

    string CreateRandomName()
    {
        return string.Format("{0} {1}", nameList.firstNames[Random.Range(0, nameList.firstNames.Count - 1)], nameList.lastNames[Random.Range(0, nameList.lastNames.Count - 1)]);
    }

    private SPirate CreateRandomPirate()
    {
        int languageNumber = Random.Range(1, 4);
        int skillNumber = Random.Range(1, 3);

        List<string> languages = new List<string>();
        List<string> skills = new List<string>();
        string pet = petList.pets[Random.Range(0, petList.pets.Count)];
        string instrument = instrumentList.instruments[Random.Range(0, instrumentList.instruments.Count)];

        for (int l = 0; l < languageNumber; l++)
        {
            string randomLang = languageList.languages[Random.Range(0, languageList.languages.Count)];
            if (!languages.Contains(randomLang))
            {
                languages.Add(randomLang);
            }
            else
                l--;
        }

        for (int s = 0; s < skillNumber; s++)
        {
            string randomSkill = skillList.skills[Random.Range(0, skillList.skills.Count)];
            if(randomSkill == "None")
            {
                skills.Clear();
                skills.Add("None");
                break;
            }
            else
            {
                if (!skills.Contains(randomSkill))
                {
                    skills.Add(randomSkill);
                }
                else
                    s--;
            }
        }

        SPirate pirate = new SPirate(CreateRandomName(), Random.Range(1000, 5000), Random.Range(15, 60), pet, instrument, skills.ToArray(), languages.ToArray(), Random.ColorHSV());
        return pirate;
    }

    private void DisplayProfil(SPirate data)
    {
        displayedCard.GetComponent<CardDisplayer>().SetPictureColor(data.pictureColor);
        TMP_profilName.text = $"Name : {data.name}";
        TMP_profilSalary.text = $"Salary : {data.salary}$";
        TMP_profilAge.text = $"Age : {data.age}";
        TMP_profilPet.text = $"Pet : {data.pet}";
        TMP_profilSkills.text = $"Skills: {StringArrayToString(data.skills)}";
        TMP_profilInstrument.text = $"Instrument : {data.instrument}";
        TMP_profilLanguages.text = $"Languages : {StringArrayToString(data.languages)}";
    }


    private string StringArrayToString(string[] array)
    {
        string s = "";
        for (int i = 0; i < array.Length; i++)
        {
            if (i < array.Length - 1)
                s += $"{array[i]}, ";
            else
                s += array[i];
        }
        return s;

    }
}