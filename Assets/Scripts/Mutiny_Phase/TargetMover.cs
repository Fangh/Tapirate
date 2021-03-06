﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening;

public class TargetMover : MonoBehaviour
{
	public float speed = 1f;
	float yInverted = -1;

	// Use this for initialization
	void Start()
	{
		Input.gyro.enabled = true;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Managers.Instance.settingsManager.inverseY)
			yInverted = 1;
		else
			yInverted = -1;
		
		Vector3 move = Vector3.zero;

#if UNITY_ANDROID && !UNITY_EDITOR
			if (Managers.Instance.settingsManager.horizontalMode)
				move = new Vector3(Input.acceleration.x, -Input.acceleration.y * yInverted, 0) * Time.deltaTime * speed * 2f;
			else
				move = new Vector3(Input.acceleration.x, Input.acceleration.z * yInverted, 0) * Time.deltaTime * speed * 2f;
#else
        move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0) * Time.deltaTime * speed;
#endif

        Rect screenSpace = new Rect(0,0,Screen.width, Screen.height);
		Vector3 posInScreenSpace = Camera.main.WorldToScreenPoint(transform.position + move);
		
		//Debug.Log("new pos : " + posInScreenSpace + " is in " + screenSpace + " ? ");
		if (screenSpace.Contains(posInScreenSpace))
		{
			transform.Translate(move);
		}	
	}
}
