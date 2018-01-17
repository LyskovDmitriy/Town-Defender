using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour 
{

	public GameObject gameOverScreen;


	void Start()
	{
		BlockForBuilding.ranOutOfLives += GameOver;
	}
		

	void GameOver()
	{
		gameOverScreen.SetActive(true);
	}


	void OnDestroy()
	{
		BlockForBuilding.ranOutOfLives -= GameOver;
	}
}
