using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndlessGameOverUI : GameOverUI 
{

	public Text currentTimeText;
	public Text maxTimeText;


	protected override void GameLost()
	{
		base.GameLost();
		int currentTime = Mathf.RoundToInt(EndlessLevelManager.DifficultyCounter);
		currentTimeText.text = currentTime.ToString();

		if (PlayerPrefs.HasKey("Max time"))
		{
			int maxTime = PlayerPrefs.GetInt("Max time");
			if (maxTime >= currentTime)
			{
				maxTimeText.text = maxTime.ToString();
			}
			else
			{
				PlayerPrefs.SetInt("Max time", currentTime);
				maxTimeText.text = currentTime.ToString();
			}
		}
		else
		{
			PlayerPrefs.SetInt("Max time", currentTime);
			maxTimeText.text = currentTime.ToString();
		}
	}
}
