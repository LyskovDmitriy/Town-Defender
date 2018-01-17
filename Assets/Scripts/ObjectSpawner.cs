using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour 
{

	public GameObject spawnObjectPrefab;
	public Transform leftBorder;
	public Transform rightBorder;
	public float timeBetweenSpawns;

	
	void Start () 
	{
		StartCoroutine(Spawn());
	}
	
	
	IEnumerator Spawn () 
	{
		while (true)
		{
			yield return new WaitForSeconds(timeBetweenSpawns);
			Vector3 randomPosition = Vector3.Lerp(leftBorder.position, rightBorder.position, Random.Range(0.0f, 1.0f));
			Instantiate(spawnObjectPrefab, randomPosition, Quaternion.identity);
		}
	}
}
