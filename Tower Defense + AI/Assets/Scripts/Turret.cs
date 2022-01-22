using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
	
    private Transform target;
	private Color color;
    private List<GameObject> enemies;

	[Header("Attributes")]
	public float range = 10f;
	public float fireRate = 1f;
	private float fireCountDown = 0f;


	[Header("UnitySetupFields")]
	public Transform partToRotate;
	public float turnSpeed = 10f;

	public GameObject bulletPrefab;
	public Transform firePoint;

	// Start is called before the first frame update
	void Start()
    {
		enemies = new List<GameObject>();
		InvokeRepeating("UpdateTarget", 0f, 0.25f);
	}

	private void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Enemy")
		{
			Debug.Log("Enemy Detected: " + other.gameObject.transform.position);
			enemies.Add(other.gameObject);
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "Enemy")
		{
			Debug.Log("Enemy Exited: " + other.gameObject.transform.position);
			enemies.Remove(other.gameObject);
		}
	}

	public void removeEnemy(GameObject _deadEnemy)
	{
		enemies.Remove(_deadEnemy);
	}

	void UpdateTarget()
	{
		float shortestDistance = Mathf.Infinity;
		GameObject nearestEnemy = null;
		if (enemies.Count <= 0)
			return;
		foreach (GameObject enemy in enemies)
		{
			float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
			if (distanceToEnemy < shortestDistance)
			{
				shortestDistance = distanceToEnemy;
				nearestEnemy = enemy;
			}
		}

		if(nearestEnemy != null && shortestDistance <= range)
		{
			target = nearestEnemy.transform;
			color = nearestEnemy.GetComponent<Renderer>().material.GetColor("_Color");
		}
		else
		{
			target = null;
		}
	}

    // Update is called once per frame
    void Update()
    {
		if (target == null)
			return;

		Vector3 dir = target.position - transform.position;
		Quaternion lookRotation = Quaternion.LookRotation(dir);
		Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime*turnSpeed).eulerAngles;
		partToRotate.rotation = Quaternion.Euler (0f, rotation.y, 0f);

		if(fireCountDown <= 0f)
		{
			Shoot();
			fireCountDown = 1f / fireRate;
		}

		fireCountDown -= Time.deltaTime;
    }

	public void Shoot()
	{
		GameObject bulletInst = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
		Bullet bullet = bulletInst.GetComponent<Bullet>();
		
		if(bullet != null)
		{
			bullet.Seek(target, color, gameObject);
		}
	}

	private void OnDrawGizmosSelected()
	{
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, range);
	}
}
