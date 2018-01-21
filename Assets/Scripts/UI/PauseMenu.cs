using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour 
{

	public GameObject pauseScreen;


	private bool isPaused = false;


	public void Pause()
	{
		pauseScreen.SetActive(true);
		Time.timeScale = 0.0f;
		isPaused = true;
	}


	public void Resume()
	{
		pauseScreen.SetActive(false);
		Time.timeScale = 1.0f;
		isPaused = false;
	}


	void OnDestroy()
	{
		Time.timeScale = 1.0f;
	}


	void Update()
	{
		#if UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN
		if (Input.GetButtonDown("Cancel"))
		{
			if (isPaused)
			{
				Resume();
			}
			else
			{
				Pause();
			}
		}
		#endif
	}
}
