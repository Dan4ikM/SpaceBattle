using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : Obstacle
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

    protected virtual void Shoot()
    {
        foreach (Transform point in gunPoint)
        {
            GameObject projectile = Instantiate(projectilePrefab, point);
            projectile.transform.parent = transform.parent;
            projectile.GetComponent<Projectile>().Initialize(gameObject.tag, ParentObj);
        }
    }

    protected override void Destruction(GameObject whoDestroy)
    {
        base.Destruction(whoDestroy);

        if (whoDestroy != null)
            whoDestroy.GetComponent<PlayerShip>().Set_Points(Points);
    }
}
