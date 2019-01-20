using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingsManager : MonoBehaviour
{
	public bool horizontalMode = true;
	public bool inverseY = false;
	int score = 0;
	
	public void ToggleHorizontalMode()
	{
		horizontalMode = !horizontalMode;
	}

	public void ToggleInverseY()
	{
		inverseY = !inverseY;
	}

	public void Score(int s)
	{
		score += s;
	}
}
