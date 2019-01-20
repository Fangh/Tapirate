using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Bullet : MonoBehaviour
{
    [Header("Tweaking")]
	[SerializeField] private LayerMask shieldLayer;
    [SerializeField] private float shakeStrength = 1;
    [SerializeField] private int shakeVibrato = 10;
    [SerializeField] private float timeBeforeHit = 2;
    [SerializeField] private float yTarget = -4f;
    [SerializeField] private float endScale = 3f;

    // Use this for initialization
    void Start ()
	{
		Vector3 pos = transform.position;
		GetComponent<Transform>().DOScale(endScale, timeBeforeHit).OnComplete(Hit).SetEase(Ease.Linear);
		GetComponent<Transform>().DOShakePosition(timeBeforeHit, shakeStrength, shakeVibrato);
		GetComponent<Transform>().DOMoveY(yTarget, timeBeforeHit).SetEase(Ease.Linear);
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
	
	void Hit()
	{
		if (Physics2D.OverlapPoint(transform.position, shieldLayer))
		{
			ShieldMover.Instance.Hit();
		}
		else
		{
			Camera.main.DOShakePosition(0.5f, 0.25f, 10);
		}
		Destroy(gameObject);
	}
}