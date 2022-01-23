using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public GameObject impactEffect;
    public Material impactMaterial;

    public int damage;

    private Transform target;
    private Color impactColor;

    private GameObject turret;

    private ExplosionRange expRange;

    public float speed = 70f;


    public void Seek (Transform _target, Color _color, GameObject _turret)
	{
        target = _target;
        impactColor = _color;
        turret = _turret;
        expRange = GetComponent<ExplosionRange>();
	}
    // Update is called once per frame
    void Update()
    {
        if(target == null)
		{
            Destroy(gameObject);
            return; 
		}

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if(dir.magnitude <= distanceThisFrame)
		{
            
            MissileHitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);

    }

    void MissileHitTarget()
	{
        GameObject effectInst = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectInst, 2f);

        Turret script = turret.GetComponent<Turret>();

        foreach (GameObject enemy in expRange.enemies)
		{
            bool isDead = enemy.GetComponent<Enemy_Health>().GetHit(damage);
            if (isDead)
            {
                script.removeEnemy(enemy);
                Destroy(enemy);
            }
        }

        Destroy(gameObject);
	}
}
