using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelectMenu : MonoBehaviour 
{

	public ButtonRequest[] requests;

	
	public void LoadLevel(string levelName)
	{
		SceneManager.LoadScene(levelName);
	}


	void Start()
	{
		foreach (ButtonRequest request in requests)
		{
			if (PlayerPrefs.HasKey(request.requestName) && PlayerPrefs.GetInt(request.requestName) >= 1)
			{
				continue;
			}
			else
			{
				request.targetButton.enabled = false;
				request.targetButton.GetComponent<Image>().fillCenter = false;
			}
		}
	}
}
