using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catapult : MonoBehaviour 
{

	public GameObject projectilePrefab;
	public Transform placeForProjectile;
	public Transform frontLineStart;
	public Transform backLineStart;
	public LineRenderer frontLine;
	public LineRenderer backLine;
	public int numberOfLinePositions;
	public float timeToSpawnProjectile;


	private SpringJoint spring;
	private bool startedSpawning;

	
	void Start () 
	{
		spring = GetComponent<SpringJoint>();
		frontLine.positionCount = numberOfLinePositions;
		backLine.positionCount = numberOfLinePositions;
		startedSpawning = false;
	}
	
	
	void Update () 
	{
		if (spring.connectedBody == null && !startedSpawning)
		{
			StartCoroutine(SpawnProjectile());
		}
		if (spring.connectedBody != null)
		{
			UpdateLine();
		}
		else
		{
			frontLine.enabled = false;
			backLine.enabled = false;
		}
	}


	IEnumerator SpawnProjectile()
	{
		//Debug.Log("Spawn");
		startedSpawning = true;
		yield return new WaitForSeconds(timeToSpawnProjectile);
		Projectile projectile = Instantiate(projectilePrefab, placeForProjectile).GetComponent<Projectile>();
		projectile.gameObject.transform.localPosition = Vector3.zero;
		spring.connectedBody = projectile.GetComponent<Rigidbody>();
		projectile.anchor = placeForProjectile;
		projectile.spring = spring;
		startedSpawning = false;
	}


	void UpdateLine()
	{
		frontLine.enabled = true;
		backLine.enabled = true;
		Transform projectile = spring.connectedBody.transform;
		SphereCollider collider = projectile.GetComponent<SphereCollider>();

		frontLine.SetPosition(0, frontLineStart.position);
		Vector3 frontDirection = (projectile.position - frontLineStart.position).normalized;
		frontLine.SetPosition(1, projectile.position - Vector3.forward * collider.bounds.extents.z);

		backLine.SetPosition(0, backLineStart.position);
		Vector3 backDirection = (projectile.position - backLineStart.position).normalized;
		backLine.SetPosition(1, projectile.position + Vector3.forward * collider.bounds.extents.z);
	}
}
