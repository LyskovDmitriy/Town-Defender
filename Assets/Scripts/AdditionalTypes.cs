using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct ObjectForSpawner
{
	public string name;
	public GameObject spawnObjectPrefab;
	public float objectSize;
	public float objectMass;
	public float objectDrag;
}

[System.Serializable]
public struct ButtonRequest
{
	public string requestName;
	public Button targetButton;
}

public enum ProjectileType { Snow, Water, Dirt }
