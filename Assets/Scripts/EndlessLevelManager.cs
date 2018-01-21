using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessLevelManager : MonoBehaviour 
{

	public static float DifficultyCounter { get; private set; }


	public DifficultyInfo difficultyInfo;
	public GameObject[] houses;
	public int timeBetweenDifficultyChanges;


	private ObjectSpawner spawner;



	void Awake () 
	{
		spawner = FindObjectOfType<ObjectSpawner>();
		int randomHouseNumber = Random.Range(0, houses.Length);
		Instantiate(houses[randomHouseNumber], Vector3.zero, Quaternion.identity);
	}


	void Start()
	{
		DifficultyCounter = 0.0f;
		StartCoroutine(ChangeDifficultyOverTime());
	}


	IEnumerator ChangeDifficultyOverTime()
	{
		while (true)
		{
			ChangeDifficulty();
			yield return new WaitForSeconds(timeBetweenDifficultyChanges);
			DifficultyCounter += timeBetweenDifficultyChanges;
		}
	}


	void ChangeDifficulty()
	{
		float difficultyMultiplier = Mathf.Clamp(DifficultyCounter / difficultyInfo.timeToMaxDifficulty, 0.0f, 1.0f);

		float time = Mathf.Lerp(difficultyInfo.maxTimeBetweenSpawns, difficultyInfo.minTimeBetweenSpawns, difficultyMultiplier);
		float size = Mathf.Lerp(difficultyInfo.maxSize, difficultyInfo.minSize, difficultyMultiplier);
		float mass = Mathf.Lerp(difficultyInfo.minMass, difficultyInfo.maxMass, difficultyMultiplier);
		float drag = Mathf.Lerp(difficultyInfo.maxDrag, difficultyInfo.minDrag, difficultyMultiplier);

		spawner.ApplyDifficulty(time, size, mass, drag);
	}
}
