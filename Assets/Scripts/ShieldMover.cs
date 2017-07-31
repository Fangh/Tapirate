using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ShieldMover : MonoBehaviour
{
	public TargetMover targetMover;
	public float minY = -10f;
	public float maxY = -4f;
	public float speed = 10f;
	float move;

	public static ShieldMover Instance;

	private void Awake()
	{
		Instance = this;
	}

	// Use this for initialization
	void Start ()
	{
		if (!targetMover)
			targetMover = FindObjectOfType<TargetMover>();		
	}
	
	// Update is called once per frame
	void Update ()
	{
		MoveByTargetPos();
	}

	void MoveByTargetPos()
	{
		if (Camera.main.WorldToScreenPoint(targetMover.transform.position).y < 25)
			move = speed * Time.deltaTime;
		else if (Camera.main.WorldToScreenPoint(targetMover.transform.position).y > 100)
			move = -speed * Time.deltaTime;


		if (transform.position.y + move > minY && transform.position.y + move < maxY)
			transform.Translate(0, move, 0);
	}

	void MoveByAcceleration()
	{
		if (SettingsManager.Instance.horizontalMode)
			move = -Input.acceleration.y * Time.deltaTime * speed;
		else
			move = Input.acceleration.z * Time.deltaTime * speed;

		if (transform.position.y + move > minY && transform.position.y + move < maxY)
			transform.Translate(0, move, 0);

	}

	public void Hit()
	{
		transform.DOShakePosition(0.5f, 0.25f, 10);
	}
}
