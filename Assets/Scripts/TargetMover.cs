using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening;

public class TargetMover : MonoBehaviour
{
	public float speed = 1f;
	public bool useKeyboard = true;

	// Use this for initialization
	void Start()
	{
		Input.gyro.enabled = true;
	}
	
	// Update is called once per frame
	void Update ()
	{
		Vector3 move = Vector3.zero;
		if (useKeyboard)
			move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0) * Time.deltaTime * speed;
		else
			move = new Vector3(Input.acceleration.x, Input.acceleration.y, 0) * Time.deltaTime * speed * 2f;


		Rect screenSpace = new Rect(0,0,Screen.width, Screen.height);
		Vector3 posInScreenSpace = Camera.main.WorldToScreenPoint(transform.position + move);
		

		//Debug.Log("new pos : " + posInScreenSpace + " is in " + screenSpace + " ? ");
		if (screenSpace.Contains(posInScreenSpace))
		{
			transform.Translate(move);
		}	
	}
}
