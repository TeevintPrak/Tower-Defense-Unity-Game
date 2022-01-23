using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject impactEffect;
    public Material impactMaterial;

    private Transform target;
    private Color impactColor;

    private GameObject turret;

    public float speed = 70f;

    public void Seek (Transform _target, Color _color, GameObject _turret)
	{
        target = _target;
        impactColor = _color;
        turret = _turret;
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
            Turret script = turret.GetComponent<Turret>();
            script.removeEnemy(target.gameObject);
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
        Destroy(target.gameObject);
        Destroy(gameObject);
	}
}
