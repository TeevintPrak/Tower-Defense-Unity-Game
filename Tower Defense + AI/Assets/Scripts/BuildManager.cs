using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
	public static BuildManager instance;

	public GameObject standardTurretPrefab;
	public GameObject panelledTurretPrefab;
	public GameObject missileLauncherPrefab;
	//public GameObject laserBeamPrefab;

	private GameObject turretToBuild;

	private void Awake()
	{
		if (instance != null)
		{
			Debug.Log("More than one build manager in scene!");
			return;
		}
		instance = this;
	}

	private void Start()
	{
		turretToBuild = standardTurretPrefab;
		//turretToBuild.Add(laserBeamPrefab);
	}

	public GameObject GetTurretToBuild (int n)
	{
		if(n == 0)
		{
			return standardTurretPrefab;
		}
		else if (n == 1)
		{
			return panelledTurretPrefab;
		}
		else if(n == 2)
		{
			return missileLauncherPrefab;
		}

		return standardTurretPrefab;
	}
}
