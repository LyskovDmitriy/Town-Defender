using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour 
{

	public ObjectForSpawner[] objectsForSpawn;
	public Transform leftBorder;
	public Transform rightBorder;
	public int amountOfObjectsToSpawn;
	public int timeToGameWon;
	public float timeBetweenSpawns;

	
	void Start () 
	{
		StartCoroutine(Spawn());
	}
	
	
	IEnumerator Spawn () 
	{
		SpawnableObject.CurrentNumberOfObjects = 0;
		while (amountOfObjectsToSpawn > 0)
		{
			yield return new WaitForSeconds(timeBetweenSpawns);
			int objectNumber = Random.Range(0, objectsForSpawn.Length);
			Vector3 randomPosition = Vector3.Lerp(leftBorder.position, rightBorder.position, Random.Range(0.0f, 1.0f));
			GameObject newObject = Instantiate(objectsForSpawn[objectNumber].spawnObjectPrefab, randomPosition, Quaternion.identity);
			newObject.transform.localScale = Vector3.one * objectsForSpawn[objectNumber].objectSize;
			Rigidbody objectRB = newObject.GetComponent<Rigidbody>();
			objectRB.mass = objectsForSpawn[objectNumber].objectMass;
			objectRB.drag = objectsForSpawn[objectNumber].objectDrag;
			amountOfObjectsToSpawn--;
		}

		StartCoroutine(WaitForGameWon());
	}


	IEnumerator WaitForGameWon()
	{
		yield return new WaitForSeconds(1.0f);
		while (true)
		{
			if (SpawnableObject.CurrentNumberOfObjects <= 0)
			{
				break;
			}
			yield return null;
		}

		yield return new WaitForSeconds(0.5f);
		GameOverUI.instance.GameWon();
	}
}
