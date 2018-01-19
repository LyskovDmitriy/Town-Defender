using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileChooseButton : MonoBehaviour 
{

	public ProjectileInfo projectileInfo;
	public KeyCode buttonCode;


	private static Catapult catapult;


	public void ChooseProjectile()
	{
		catapult.SetProjectileInfo(projectileInfo);
	}


	void Start () 
	{
		if (catapult == null)
		{
			catapult = FindObjectOfType<Catapult>();
		}
	}


	void Update()
	{
		#if UNITY_EDITOR_WIN
		if (Input.GetKeyDown(buttonCode))
		{
			ChooseProjectile();
		}
		#endif
	}
}
