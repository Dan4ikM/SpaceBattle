using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : EnemyShip
{
    [SerializeField]
    private Vector3 moveRange;

    [SerializeField]
    private float horizontal;

    private void Update()
    {
        horizontal = 0;
        if (Input.GetKey(KeyCode.A))
            horizontal--;
        if (Input.GetKey(KeyCode.D))
            horizontal++;
        if (Input.GetKey(KeyCode.Space))
            ReadyToShoot();
    }

    private void FixedUpdate()
    {
        if (horizontal == 0)
            return;
        Move();
    }

    public override void Move()
    {
        Vector3 deltaMove = Vector3.right * Speed * horizontal * Time.deltaTime;

        if (moveRange.magnitude > (transform.position + deltaMove).magnitude)
            transform.position = transform.position + deltaMove;
        else
            transform.position = moveRange * horizontal;
    }
}