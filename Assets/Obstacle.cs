using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Obstacle : MonoBehaviour
{
    [SerializeField]
    protected string _tag;

    [SerializeField]
    protected int Life;

    [SerializeField]
    protected int Damage;

    [SerializeField]
    protected int Speed;

    public virtual void TakeDamage(int damage, string tag)
    {
        if (!gameObject.tag.Equals(tag))
        {
            Life -= Damage;
            if (Life <= 0)
                Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    public virtual void Move()
    {
        transform.position = transform.position + transform.up * Speed * Time.deltaTime;
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Obstacle>() != null)
            TakeDamage(other.GetComponent<Obstacle>().Damage, other.gameObject.tag);
    }
}