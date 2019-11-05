using UnityEngine;
using UnityEditor;
using System;

public class ProjectileLauncher : MonoBehaviour
{
    [SerializeField]
    private Rigidbody projectilePrefab;
    [SerializeField]
    private Transform weaponMountPoint;
    [SerializeField]
    private float fireForce = 300f;

    private void Awake()
    {
        if(GetComponent<ShipInput>() != null)
            GetComponent<ShipInput>().OnFire += HandlerFire;

        if (GetComponent<EnemyShooting>() != null)
            GetComponent<EnemyShooting>().OnFire += HandlerFire;
    }

    private void HandlerFire()
    {
        var spawnedProjectile = Instantiate(projectilePrefab, weaponMountPoint.position, weaponMountPoint.rotation);
        spawnedProjectile.AddForce(spawnedProjectile.transform.forward * fireForce);
    }
}