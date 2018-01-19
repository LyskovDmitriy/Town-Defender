using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ProjectileInfo : ScriptableObject 
{
	public ProjectileType type;
	public Material projectileMaterial;
	public float mass;
	public float baseSize;
}
