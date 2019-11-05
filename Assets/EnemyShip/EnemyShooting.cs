using System.Collections;
using System;
using UnityEngine;

public class EnemyShooting : MonoBehaviour {
    [SerializeField]
    private float rate = 1f;

    [SerializeField]
    private bool cooling = false;

    public event Action OnFire = delegate { };

    // Update is called once per frame
    void Update()
    {
        if (!cooling)
        {
            OnFire();
            StartCoroutine(Cooling());
        }
    }

    private IEnumerator Cooling()
    {
        cooling = true;
        yield return new WaitForSeconds(rate);
        cooling = false;
    }
}
