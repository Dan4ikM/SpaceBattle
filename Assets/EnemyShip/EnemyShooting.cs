using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour {

    [SerializeField]
    private GameObject projectilePrefab;

    [SerializeField]
    private float rate = 1f;

    [SerializeField]
    private bool cooling = false;

    public float Rate { get { return rate; } set { rate = value; } }

    // Update is called once per frame
    void Update()
    {
        if (!cooling)
        {
            Shoot();
            StartCoroutine(Cooling());
        }
    }

    private IEnumerator Cooling()
    {
        cooling = true;
        yield return new WaitForSeconds(rate);
        cooling = false;
    }

    private void Shoot()
    {
        GameObject projectile = Instantiate(projectilePrefab, transform);
        projectile.transform.parent = null;
    }
}
