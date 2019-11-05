using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : Ship
{
    [SerializeField]
    private Vector3 moveRange;

    [SerializeField]
    private float horizontal;

    [SerializeField]
    private PlayerUI UI;

    [SerializeField]
    public void Set_Points(int points)
    {
        if (points == 0)
            return;

        Points += points;
        UI.UpdatePoints(Points);
    }

    private void Awake()
    {
        ParentObj = gameObject;
        UI.Initialize(Life);
    }

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

    protected override void ChangeLife(int damage)
    {
        base.ChangeLife(damage);
        UI.UpdateHealth(Life);
    }

    protected override void Destruction(GameObject whoDestroy)
    {
        base.Destruction(whoDestroy);
        GameManager.instance.EndGame();
    }
}