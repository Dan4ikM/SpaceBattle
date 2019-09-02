using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : Obstacle
{
    [SerializeField]
    private GameObject projectilePrefab;

    [SerializeField]
    private Transform[] gunPoint;

    [SerializeField]
    private float Rate;

    [SerializeField]
    private bool IsCooling;

    void Update()
    {
        ReadyToShoot();
    }

    protected void ReadyToShoot()
    {
        if (!IsCooling)
        {
            Shoot();
            StartCoroutine(Cooling());
        }
    }

    protected IEnumerator Cooling()
    {
        IsCooling = true;
        yield return new WaitForSeconds(Rate);
        IsCooling = false;
    }

    protected void Shoot()
    {
        foreach (Transform point in gunPoint)
        {
            GameObject projectile = Instantiate(projectilePrefab, point);
            projectile.transform.parent = null;
            projectile.GetComponent<Projectile>().Initialize(gameObject.tag);
        }
    }
}
