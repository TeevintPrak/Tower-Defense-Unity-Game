using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Health : MonoBehaviour
{
    public int value = 10;
    public float baseHealth = 10;
    private float Health;

    public GameObject gameManager;
    // Start is called before the first frame update
    void Start()
    {
        baseHealth = Health;
    }

    public bool GetHit(int damage)
	{
        Health -= damage;
        
        if(Health <= 0)
		{
            Debug.Log("Dead");
            BuildManager.instance.addMoney(value);
            return true;
		}
        return false;
	}

    public void SetHealth(float multiplier)
	{
        Health = baseHealth * multiplier;
	}
}
