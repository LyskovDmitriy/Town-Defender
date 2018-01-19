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
	public ProjectileInfo projectileInfo;
	public int numberOfLinePositions;
	public float timeToSpawnProjectile;


	private SpringJoint spring;
	private Projectile currentProjectile;
	private bool startedSpawning;


	public void SetProjectileInfo(ProjectileInfo info)
	{
		projectileInfo = info;
		if (currentProjectile.transform.parent == placeForProjectile)
		{
			currentProjectile.SetProjectileInfo(projectileInfo);
		}
	}

	
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
			startedSpawning = true;
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
		yield return new WaitForSeconds(timeToSpawnProjectile);
		currentProjectile = Instantiate(projectilePrefab, placeForProjectile.position, Quaternion.identity).GetComponent<Projectile>();
		currentProjectile.transform.SetParent(placeForProjectile);
		currentProjectile.SetProjectileInfo(projectileInfo);
		spring.connectedBody = currentProjectile.GetComponent<Rigidbody>();
		currentProjectile.anchor = placeForProjectile;
		currentProjectile.spring = spring;
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
