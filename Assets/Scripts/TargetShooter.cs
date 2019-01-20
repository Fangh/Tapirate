using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

public class TargetShooter : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private List<AudioClip> hitSFX = new List<AudioClip>();
    [SerializeField] private List<AudioClip> shotSFX = new List<AudioClip>();

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetButtonDown("Fire") || Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            transform.DOShakePosition(0.5f, 0.05f, 50, 90);
            AudioSource.PlayClipAtPoint(shotSFX[Random.Range(0, shotSFX.Count)], transform.position);
            Collider2D hit = Physics2D.OverlapPoint(transform.position);
            if (hit != null)
            {
                if (hit.name == "Body")
                {
                    if (hit.GetComponentInParent<PirateBehavior>().Hit("Body"))
                        GetComponent<AudioSource>().PlayOneShot(hitSFX[Random.Range(0, hitSFX.Count)]);
                }
                else if (hit.name == "Head")
                {
                    if (hit.GetComponentInParent<PirateBehavior>().Hit("Head"))
                        GetComponent<AudioSource>().PlayOneShot(hitSFX[Random.Range(0, hitSFX.Count)]);

                }
            }
        }
    }
}