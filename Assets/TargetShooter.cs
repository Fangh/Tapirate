using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TargetShooter : MonoBehaviour
{

	public List<AudioClip> hitSFX = new List<AudioClip>();
	public List<AudioClip> shotSFX = new List<AudioClip>();

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
		if (Input.GetButtonDown("Fire") || Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
		{
			transform.DOShakePosition(0.5f, 0.05f, 50, 90);
			AudioSource.PlayClipAtPoint(shotSFX[UnityEngine.Random.Range(0, shotSFX.Count)], transform.position);
			Collider2D hit = Physics2D.OverlapPoint(transform.position);
			if (hit != null && hit.name == "Pirate")
			{
				GetComponent<AudioSource>().PlayOneShot(hitSFX[UnityEngine.Random.Range(0, hitSFX.Count)]);
				hit.GetComponent<PirateBehavior>().Hit();
			}
		}

	}
}
