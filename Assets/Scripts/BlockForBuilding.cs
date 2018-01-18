using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockForBuilding : MonoBehaviour 
{

	public static event System.Action ranOutOfLives;
	public static int NumberOfBlocks { get; private set; }
	public static int Lives { get; private set; }


	private static MainUI UI;


	void Awake()
	{
		Lives = 0;
		NumberOfBlocks = 0;
		if (UI == null)
		{
			UI = FindObjectOfType<MainUI>();
		}
	}


	void Start()
	{
		if (CompareTag("TargetBlock"))
		{
			Lives++;
			UI.ChangeLives(Lives);
		}
		else
		{
			NumberOfBlocks++;
		}
	}


	void OnCollisionEnter(Collision collider)
	{
		if (collider.gameObject.CompareTag("Destructive"))
		{
			if (CompareTag("TargetBlock"))
			{
				Lives--;
				UI.ChangeLives(Lives);
				if (Lives <= 0 && ranOutOfLives != null)
				{
					ranOutOfLives();
				}
			}
			else
			{
				NumberOfBlocks--;
			}
			Destroy(collider.gameObject);
			Destroy(gameObject);
		}
	}
}
