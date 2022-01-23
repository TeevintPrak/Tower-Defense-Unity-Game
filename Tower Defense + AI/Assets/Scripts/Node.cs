using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
	public Color hoverColor;
	public Color defaultColor;

	private Renderer rend;
	private GameObject turret;
	private void Start()
	{
		rend = GetComponent<Renderer>();
		defaultColor = rend.material.color;
	}

	private void OnMouseDown()
	{
		if (turret != null)
		{
			Debug.Log("Can't build there - TODO:convey to player");
			return;
		}

		GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
		turret = (GameObject)Instantiate(turretToBuild, transform.position, transform.rotation);
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
