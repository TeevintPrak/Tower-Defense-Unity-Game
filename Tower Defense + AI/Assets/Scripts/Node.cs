using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
	public Color hoverColor;
	public Color defaultColor;

	private Renderer rend;
	private GameObject tempTurret;
	private GameObject turret;
	private GameObject turretToBuild;
	private void Start()
	{
		rend = GetComponent<Renderer>();
		defaultColor = rend.material.color;
	}

	public void Update()
	{
		if (Input.GetKeyDown("1"))
		{
			turretToBuild = BuildManager.instance.GetTurretToBuild(0);
		}
		else if (Input.GetKeyDown("2"))
		{
			turretToBuild = BuildManager.instance.GetTurretToBuild(1);
		}
		else if (Input.GetKeyDown("3"))
		{
			turretToBuild = BuildManager.instance.GetTurretToBuild(2);
		}
	}

	private void OnMouseDown()
	{
		
		if (turret != null)
		{
			Debug.Log("Can't build there - TODO:convey to player BRRT or TEXT");
			return;
		}

		if(!BuildManager.instance.purchaseTurret())
		{
			Debug.Log("Not enough money!");
			return;
		}

		turret = (GameObject)Instantiate(turretToBuild, transform.position, transform.rotation);
		/*
		else if (Input.GetKeyUp("3"))
		{
			Destroy(tempTurret);
		}
		else if (Input.GetKeyDown("4"))
		{
			turretToBuild = BuildManager.instance.GetTurretToBuild(3);
			tempTurret = (GameObject)Instantiate(turretToBuild, transform.position, transform.rotation);
		}
		else if (Input.GetKeyUp("4"))
		{
			Destroy(tempTurret);
		}*/
	}

	private void OnMouseEnter()
	{
		rend.material.color = hoverColor;
	}

	void OnMouseExit()
	{
		rend.material.color = defaultColor;
	}
}
