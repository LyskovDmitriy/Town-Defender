using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour 
{

	public ObjectForSpawner[] objectsForSpawn;
	public ProjectileInfo[] types;
	public Transform leftBorder;
	public Transform rightBorder;
	public int amountOfObjectsToSpawn;
	public float timeBetweenSpawns;


	public void ApplyDifficulty(float time, float size, float mass, float drag)
	{
		timeBetweenSpawns = time;
		for (int i = 0; i < objectsForSpawn.Length; i++)
		{
			objectsForSpawn[i].objectSize = size;
			objectsForSpawn[i].objectMass = mass;
			objectsForSpawn[i].objectDrag = drag;
		}
	}

	
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
			Quaternion randomRotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, Random.Range(0.0f, 360.0f)));
			GameObject newObject = Instantiate(objectsForSpawn[objectNumber].spawnObjectPrefab, randomPosition, randomRotation);
			newObject.transform.localScale = Vector3.one * objectsForSpawn[objectNumber].objectSize;
			Rigidbody objectRB = newObject.GetComponent<Rigidbody>();
			objectRB.mass = objectsForSpawn[objectNumber].objectMass;
			objectRB.drag = objectsForSpawn[objectNumber].objectDrag;
			if (types.Length > 0)
			{
				ProjectileInfo info = types[Random.Range(0, types.Length)];
				newObject.GetComponent<SpawnableObject>().ApplyType(info);
			}
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
