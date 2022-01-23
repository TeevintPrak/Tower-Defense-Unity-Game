using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildManager : MonoBehaviour
{
	public static BuildManager instance;

	public GameObject standardTurretPrefab;
	public GameObject fastTurretPrefab;
	public GameObject missileLauncherPrefab;
	//public GameObject laserBeamPrefab;

	private GameObject turretToBuild;

	public int currency;
	public int priceStandard;
	public int priceFast;
	public int priceMissile;

	private int turretID;
	private int invasions;

	public Text moneyText;
	public Text invasionText;

	private void Awake()
	{
		invasions = 0;
		currency = 300;
		turretID = 0;
		moneyText.text = currency.ToString();
		priceStandard = 150;
		priceFast = 200;
		priceMissile = 200;
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

	public void addMoney(int n)
	{
		currency += n;
		Debug.Log("Currency = " + currency);
	}
	
	public void addAnInvasion()
	{
		invasions += 1;
		invasionText.text = invasions.ToString();
	}

	private void FixedUpdate()
	{
		moneyText.text = currency.ToString();
		invasionText.text = invasions.ToString();
	}

	public GameObject GetTurretToBuild (int n)
	{
		if (n == 0) 
		{
			turretID = n;
			return standardTurretPrefab;
		} 
		else if (n == 1)
		{
			turretID = n;
			return fastTurretPrefab;
		}
		else if (n == 2)
		{
			turretID = n;
			return missileLauncherPrefab;
		}
		turretID = 0;
		return standardTurretPrefab;
	}

	public bool purchaseTurret()
	{
		if (turretID == 0)
		{
			if (currency >= priceStandard)
			{
				currency -= priceStandard;
				moneyText.text = currency.ToString();
				return true;
			}
			else
			{
				return false;
			}
		}
		else if (turretID == 1)
		{
			if (currency >= priceFast)
			{
				currency -= priceFast;
				moneyText.text = currency.ToString();
				return fastTurretPrefab;
			}
			else
			{
				return false;
			}
		}
		else if (turretID == 2)
		{
			if (currency >= priceMissile)
			{
				currency -= priceMissile;
				moneyText.text = currency.ToString();
				return true;
			}
			else
			{
				return false;
			}
		}

		return false;
	}

	/*
	 * 
		
	*/
}
