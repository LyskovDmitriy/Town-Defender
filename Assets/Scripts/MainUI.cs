using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainUI : MonoBehaviour 
{

	public Text livesText;

	
	public void ChangeLives (int lives) 
	{
		livesText.text = "Lives: " + lives;
	}


	public void Restart()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
