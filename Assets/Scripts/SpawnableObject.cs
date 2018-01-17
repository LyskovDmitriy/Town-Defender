using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnableObject : MonoBehaviour 
{

	private Rigidbody rb;

	
	void Start () 
	{
		rb = GetComponent<Rigidbody>();
	}
	
	
	void OnCollisionEnter ()
	{
		rb.drag = 0;
	}


	void OnBecameInvisible()
	{
		Destroy(gameObject);
	}
}
