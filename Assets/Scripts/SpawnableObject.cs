using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnableObject : MonoBehaviour 
{

	public static int CurrentNumberOfObjects { get; set; }


	public float massMultiplierWithWrongProjectile;


	public ProjectileType type;


	private Rigidbody rb;
	private float mass;
	private bool hasDecreasedNumber;
	private bool hasStartedCoroutine;


	public void CheckProjectileType(ProjectileType projectileType)
	{
		if (type != projectileType)
		{
			float newMass = mass * massMultiplierWithWrongProjectile;
			if (mass <= newMass)
			{
				rb.velocity /= massMultiplierWithWrongProjectile;
			}
			rb.mass = newMass;
		}
	}


	public void ApplyType(ProjectileInfo info)
	{
		GetComponent<MeshRenderer>().material = info.projectileMaterial;
		type = info.type;
	}


	IEnumerator WaitForStop()
	{
		while (true)
		{
			if (rb.velocity == Vector3.zero)
			{
				if (!hasDecreasedNumber)
				{
					hasDecreasedNumber = true;
					CurrentNumberOfObjects--;
					//Debug.Log(CurrentNumberOfObjects);
				}
				yield break;
			}
			yield return null;
		}
	}

	
	void Start () 
	{
		CurrentNumberOfObjects++;
		//Debug.Log(CurrentNumberOfObjects);
		hasDecreasedNumber = false;
		hasStartedCoroutine = false;
		rb = GetComponent<Rigidbody>();
		mass = rb.mass;
	}

	
	void OnCollisionEnter ()
	{
		rb.drag = 0;
		if (!hasStartedCoroutine)
		{
			StartCoroutine(WaitForStop());
			hasStartedCoroutine = true;
		}
	}


	void OnBecameInvisible()
	{
		if (!hasDecreasedNumber)
		{
			hasDecreasedNumber = true;
			CurrentNumberOfObjects--;
			//Debug.Log(CurrentNumberOfObjects);
		}
		Destroy(gameObject);
	}
}
