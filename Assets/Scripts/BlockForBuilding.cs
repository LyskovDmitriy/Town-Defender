using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockForBuilding : MonoBehaviour 
{

	public static event System.Action ranOutOfLives;


	private static MainUI UI;
	private static int lives = 0;


	void Start()
	{

		if (UI == null)
		{
			UI = FindObjectOfType<MainUI>();
		}
		if (CompareTag("TargetBlock"))
		{
			lives++;
			UI.ChangeLives(lives);
		}
	}


	void OnCollisionEnter(Collision collider)
	{
		if (collider.gameObject.CompareTag("Destructive"))
		{
			if (CompareTag("TargetBlock"))
			{
				lives--;
				UI.ChangeLives(lives);
				if (lives <= 0 && ranOutOfLives != null)
				{
					ranOutOfLives();
				}
			}
			Destroy(collider.gameObject);
			Destroy(gameObject);
		}
	}
}
