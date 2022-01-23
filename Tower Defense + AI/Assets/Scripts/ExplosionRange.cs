using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionRange : MonoBehaviour
{
	public List<GameObject> enemies;

	private void Start()
	{
		enemies = new List<GameObject>();
	}
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Enemy")
		{
			Debug.Log("Enemy Detected: " + other.gameObject.transform.position);
			enemies.Add(other.gameObject);
		}
	}
}
