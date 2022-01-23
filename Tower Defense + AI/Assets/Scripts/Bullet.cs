using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject impactEffect;
    public Material impactMaterial;

    public int damage;

    private Transform target;
    private Color impactColor;

    private GameObject turret;

    public float speed = 70f;

    public void Seek (Transform _target, Color _color, GameObject _turret, int _damage)
	{
        target = _target;
        impactColor = _color;
        turret = _turret;
        damage = _damage;

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
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);

    }

    void HitTarget()
	{
        impactMaterial.color = impactColor;
        GameObject effectInst = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectInst, 2f);

        Turret script = turret.GetComponent<Turret>();
        GameObject enemy = target.gameObject;

        bool isDead = enemy.GetComponent<Enemy_Health>().GetHit(damage);
        if (isDead)
        {
            script.removeEnemy(enemy);
            Destroy(enemy);
        }

        Destroy(gameObject);
	}
}
