using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private Vector3 speed = new Vector3(5,0,0);

    [SerializeField]
    private Vector3 moveRange = new Vector3(10, 0, 0);

    [SerializeField]
    private float horizontal = 0;

    // Update is called once per frame
    private void Update ()
    {
        horizontal = 0;
        if (Input.GetKey(KeyCode.A))
            horizontal--;
        if (Input.GetKey(KeyCode.D))
            horizontal++;
    }

    private void FixedUpdate()
    {
        if (horizontal == 0)
            return;
        Move();
    }

    private void Move()
    {
        Vector3 deltaMove = speed * horizontal * Time.deltaTime;
        if (moveRange.magnitude > (transform.position + deltaMove).magnitude)
        {
            transform.position = transform.position + deltaMove;
        }
        else
            transform.position = moveRange * horizontal;
    }

}
