using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Bullet : MonoBehaviour
{
	public LayerMask layer;
	public float shakeStrength = 1;
	public int shakeVibrato = 10;
	public float timeBeforeHit = 2;

	// Use this for initialization
	void Start ()
	{
		Vector3 pos = transform.position;
		GetComponent<Transform>().DOScale(1.5f, timeBeforeHit).OnComplete(Hit);
		GetComponent<Transform>().DOShakePosition(timeBeforeHit, shakeStrength, shakeVibrato);
		GetComponent<Transform>().DOMoveY(pos.y - 1, timeBeforeHit);
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
	
	void Hit()
	{
		if (Physics2D.OverlapPoint(transform.position, layer))
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