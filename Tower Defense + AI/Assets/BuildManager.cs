using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
	public static BuildManager instance;

	public GameObject standardTurretPrefab;

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
	}

	public GameObject GetTurretToBuild ()
	{
		return turretToBuild;
	}
}
