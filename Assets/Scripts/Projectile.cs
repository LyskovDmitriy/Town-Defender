using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour 
{

	public SpringJoint spring;
	public Transform anchor;
	public ProjectileType type;
	public float maxDistance;


	private MeshRenderer renderer;
	private Rigidbody rb;
	private Vector3 previousVelocity;
	private float cameraOffsetZ;
	private bool isMousePressed = false;
	private bool isReleased = false;


	public void SetProjectileInfo(ProjectileInfo info)
	{
		type = info.type;
		renderer.material = info.projectileMaterial;
		rb.mass = info.mass;
		transform.localScale = Vector3.one * info.baseSize * transform.localScale.x / transform.lossyScale.x;
	}


	void Awake()
	{
		renderer = GetComponent<MeshRenderer>();
		rb = GetComponent<Rigidbody>();
	}


	void Start()
	{
		previousVelocity = Vector3.zero;
		rb.isKinematic = true;
		cameraOffsetZ = -Camera.main.transform.position.z;
	}


	void Update()
	{
		if (isMousePressed && !isReleased)
		{
			if (Input.GetMouseButtonUp(0))
			{		
				isMousePressed = false;
				isReleased = true;
				rb.isKinematic = false;
			}
			else
			{
				Vector3 mousePosition = Input.mousePosition;
				mousePosition.z = cameraOffsetZ;
				mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
				mousePosition.z = transform.position.z;
				if (Vector3.Distance(mousePosition, anchor.position) > maxDistance)
				{
					Vector3 direction = (mousePosition - anchor.position).normalized;
					Ray ray = new Ray(anchor.position, direction);
					Vector3 newPosition = ray.GetPoint(maxDistance);
					transform.position = newPosition;
				}
				else
				{
					transform.position = mousePosition;
				}
			}

		}

		if (isReleased)
		{
			if (rb.velocity.sqrMagnitude < previousVelocity.sqrMagnitude)
			{
				Release();
			}
			else
			{
				previousVelocity = rb.velocity;
			}
		}
	}


	void Release()
	{
		rb.velocity = previousVelocity;
		spring.connectedBody = null;
		isReleased = false;
		transform.SetParent(null);
		enabled = false;
	}


	void OnMouseDown()
	{
		isMousePressed = true;
	}


	void OnBecameInvisible()
	{
		Destroy(gameObject);
	}


	void OnCollisionEnter(Collision collider)
	{
		SpawnableObject obj = collider.gameObject.GetComponent<SpawnableObject>();
		if (obj != null)
		{
			obj.CheckProjectileType(type);
		}
	}
}
