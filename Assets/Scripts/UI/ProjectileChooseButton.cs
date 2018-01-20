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
		if (catapult == null)
		{
			catapult = FindObjectOfType<Catapult>();
			if (catapult == null)
			{
				return;
			}
		}
		catapult.SetProjectileInfo(projectileInfo);
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
