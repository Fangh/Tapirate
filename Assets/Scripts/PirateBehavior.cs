using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PirateBehavior : MonoBehaviour
{
	float currentCooldown = 0f;
	float cooldown = 0f;

	public float cooldownMin = 1f;
	public float cooldownMax = 5f;

	public float movementDurationMin = 0.5f;
	public float movementDurationMax = 2f;
	float movementDuration = 0f;

	bool canGoOut = false;
	public bool isDying = false;

	bool isHidden = true;

	Vector3 originalPos;

	public float flashTime = 1f;
	public float flashAmplitude = 5;
	public float flashPeriod = 1f;

	Tweener movementTween;

	public List<AudioClip> voices = new List<AudioClip>();

	public GameObject pointPrefab;

	// Use this for initialization
	void Start ()
	{
		ResetCooldown();
		originalPos = transform.localPosition;
		
	}

	void ResetCooldown()
	{
		cooldown = Random.Range(cooldownMin, cooldownMax);
		currentCooldown = 0f;
		movementDuration = Random.Range(movementDurationMin, movementDurationMax);
		canGoOut = true;
	}
	

	// Update is called once per frame
	void Update ()
	{
		if (isDying)
			return;

		// go out
		if (currentCooldown > cooldown)
		{
			if (!canGoOut)
				return;

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
	}

	[ContextMenu("Hit")]
	public void Hit()
	{
		if (isHidden)
			return;

		if (!isDying)
		{
			movementTween.Kill();

			GameObject go = Instantiate(pointPrefab, transform.position, Quaternion.identity);
			go.GetComponent<SpriteRenderer>().DOFade(0, 2f);
			go.transform.DOMoveY(go.transform.position.y + 2f, 2f);
			Destroy(go, 2.5f);

			GetComponent<SpriteRenderer>().DOColor(new Color(0, 0, 0, 0), flashTime).SetEase(Ease.InOutFlash, flashAmplitude, flashPeriod).OnComplete( () => 
			{
				ResetCooldown();
				isDying = false;
				transform.localPosition = originalPos;
				GetComponent<SpriteRenderer>().color = Color.white;
			});
			isDying = true;
		}

	}
}
