using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour 
{
	
	public void LoadLevelSelect()
	{
		SceneManager.LoadScene("LevelSelect");
	}


	public void ExitGame()
	{
		Application.Quit();
	}
}
