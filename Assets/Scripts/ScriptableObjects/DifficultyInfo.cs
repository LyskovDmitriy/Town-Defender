using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class DifficultyInfo : ScriptableObject 
{
	public int timeToMaxDifficulty;

	public float maxTimeBetweenSpawns;
	public float minTimeBetweenSpawns;

	public float maxSize;
	public float minSize;

	public float maxMass;
	public float minMass;

	public float maxDrag;
	public float minDrag;
}
