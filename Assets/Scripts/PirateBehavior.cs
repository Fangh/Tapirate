using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

public class PirateBehavior : MonoBehaviour
{
    [Header("Tweaking")]
    [SerializeField] private S_MinMax cooldownRandomized = new S_MinMax(1f, 5f);
    [SerializeField] private S_MinMax movementDurationRandomized = new S_MinMax(0.5f, 2f);
    [SerializeField] private S_MinMax fireFrequenceRandomized = new S_MinMax(2, 7);
    [SerializeField] private float flashTime = 1f;
    [SerializeField] private float flashAmplitude = 5;
    [SerializeField] private float flashPeriod = 1f;

    [Header("References")]
    [SerializeField] private GameObject muzzleFlash;
    [SerializeField] private GameObject pointPrefab;
    [SerializeField] private GameObject point2Prefab;
    [SerializeField] private GameObject bulletPrefab = null;
    [SerializeField] private List<AudioClip> voices = new List<AudioClip>();

    private float currentCooldown = 0f;
    private float cooldown = 0f;
    private float movementDuration = 0f;
    private int fireFrequence = 0;
    private int currentExitCount = 0;

    private bool canGoOut = false;
    private bool isDying = false;
    private bool isHidden = true;

    private Vector3 originalPos;
    private Tweener movementTween;


    // Use this for initialization
    void Start()
    {
        ResetCooldown();
        originalPos = transform.localPosition;
        ResetFireCount();
    }

    void ResetFireCount()
    {
        currentExitCount = 0;
        fireFrequence = Random.Range((int)fireFrequenceRandomized.min, (int)fireFrequenceRandomized.max);
    }

    void ResetCooldown()
    {
        cooldown = Random.Range(cooldownRandomized.min, cooldownRandomized.max);
        currentCooldown = 0f;
        movementDuration = Random.Range(movementDurationRandomized.min, movementDurationRandomized.max);
        canGoOut = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDying)
            return;

        // go out
        if (currentCooldown > cooldown)
        {
            if (!canGoOut)
                return;

            currentExitCount++;
            isHidden = false;
            canGoOut = false;
            GetComponent<AudioSource>().PlayOneShot(voices[Random.Range(0, voices.Count)]);
            movementTween = transform.DOLocalMoveY(1.3f, movementDuration).SetLoops(2, LoopType.Yoyo).OnComplete(ResetCooldown);
            //Debug.Log("GO !");
        }
        else
        {
            currentCooldown += Time.deltaTime;
            isHidden = true;
        }

        if (currentExitCount >= fireFrequence)
        {
            ResetFireCount();
            Fire();
        }
    }

    void Fire()
    {
        Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        muzzleFlash.SetActive(true);
        muzzleFlash.transform.DOScale(2, 0.2f).OnComplete(() => 
        {
            muzzleFlash.transform.localScale = Vector3.zero;
            muzzleFlash.SetActive(false);
        });
    }

    [ContextMenu("Hit")]
    public bool Hit(string bodyPart)
    {
        if (isHidden)
            return false;

        if (!isDying)
        {
            movementTween.Kill();

            GameObject go;

            if (bodyPart == "Head")
            {
                go = Instantiate(point2Prefab, transform.position, Quaternion.identity);
                SettingsManager.Instance.Score(2);
            }
            else
            {
                go = Instantiate(pointPrefab, transform.position, Quaternion.identity);
                SettingsManager.Instance.Score(1);
            }

            go.GetComponent<SpriteRenderer>().DOFade(0, 2f);
            go.transform.DOMoveY(go.transform.position.y + 2f, 2f);
            Destroy(go, 2.5f);

            GetComponent<SpriteRenderer>().DOColor(new Color(0, 0, 0, 0), flashTime).SetEase(Ease.InOutFlash, flashAmplitude, flashPeriod).OnComplete(() =>
           {
               ResetCooldown();
               isDying = false;
               transform.localPosition = originalPos;
               GetComponent<SpriteRenderer>().color = Color.white;
           });
            isDying = true;
        }

        return true;
    }
}