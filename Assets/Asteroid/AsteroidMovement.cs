using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovement : MonoBehaviour {

    [SerializeField]
    private Vector3 speed = new Vector3(0, 3, 0);
    [SerializeField]
    private float lifetime = 10;

    private void Awake()
    {
        Destroy(gameObject, lifetime);
    }

    private void FixedUpdate()
    {
        transform.position = transform.position + speed * Time.deltaTime;
    }
}
