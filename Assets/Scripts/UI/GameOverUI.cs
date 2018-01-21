using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour 
{

	public static GameOverUI instance;
	

	public PointsPerObjectives pointsList;
	public GameObject gameOverScreen;
	public GameObject pointsObject;
	public Text gameOverText;
	public Text pointsForBlocksText;
	public Text pointsForTargetsText;
	public Text totalPointsText;


	private bool isGameLost = false;
	private bool isGameWon = false;


	public void GameWon()
	{
		if (!isGameLost)
		{
			isGameWon = true;
			gameOverScreen.SetActive(true);
			gameOverText.text = "Game Won";
			DisplayScore();
			PlayerPrefs.SetInt(SceneManager.GetActiveScene().name, 1);
		}
	}


	protected virtual void GameLost()
	{
		if (!isGameWon)
		{
			isGameLost = true;
			gameOverScreen.SetActive(true);
			if (pointsObject != null)
			{
				pointsObject.SetActive(false);
			}
		}
	}


	void Start()
	{
		if (instance == null)
		{
			instance = this;
		}
		else if (instance != this)
		{
			Destroy(gameObject);
		}

		BlockForBuilding.ranOutOfLives += GameLost;
	}


	void DisplayScore()
	{
		int blocksPoints = BlockForBuilding.NumberOfBlocks * pointsList.pointsPerBlock;
		int targetPoints = BlockForBuilding.Lives * pointsList.pointsPerTarget;
		int totalPoints = blocksPoints + targetPoints;
		pointsForBlocksText.text = BlockForBuilding.NumberOfBlocks + " * " + pointsList.pointsPerBlock + " = " + blocksPoints;
		pointsForTargetsText.text = BlockForBuilding.Lives + " * " + pointsList.pointsPerTarget + " = " + targetPoints;
		totalPointsText.text = totalPoints.ToString();
	}


	void OnDestroy()
	{
		BlockForBuilding.ranOutOfLives -= GameLost;
	}
}
