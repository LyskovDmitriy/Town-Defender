using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnableObject : MonoBehaviour 
{

	public static int CurrentNumberOfObjects { get; set; }


	private Rigidbody rb;
	private bool hasDecreasedNumber;
	private bool hasStartedCoroutine;


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
