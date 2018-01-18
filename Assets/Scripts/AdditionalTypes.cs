using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct ObjectForSpawner
{
	public string name;
	public GameObject spawnObjectPrefab;
	public float objectSize;
	public float objectMass;
	public float objectDrag;
}
