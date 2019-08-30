using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    [SerializeField]
    private Vector3 speed = new Vector3(0, 10, 0);

    private void Awake()
    {
        Destroy(gameObject, 2);
    }

    private void FixedUpdate()
    {
        transform.position = transform.position + speed * Time.deltaTime;
    }
}
