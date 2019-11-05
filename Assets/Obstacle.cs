using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Obstacle : MonoBehaviour
{
    [SerializeField]
    protected GameObject ParentObj;

    [SerializeField]
    protected int Points;

    [SerializeField]
    protected int Life;

    [SerializeField]
    protected int Damage;

    [SerializeField]
    protected int Speed;

    public virtual void TakeDamage(int damage, string tag, GameObject whoDamaged)
    {
        if (!gameObject.tag.Equals(tag))
        {
            ChangeLife(damage);
            if (Life <= 0)
            {
                Destruction(whoDamaged);
            }
        }
    }

    protected virtual void ChangeLife(int damage)
    {
        Life -= damage;
    }

    protected virtual void Destruction(GameObject whoDestroy)
    {
        Destroy(gameObject);
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
        if (other.gameObject.tag.Equals("Destroyer"))
            Destruction(null);
        if(other.GetComponent<Obstacle>() != null)
            TakeDamage(other.GetComponent<Obstacle>().Damage, other.gameObject.tag, other.GetComponent<Obstacle>().ParentObj);
    }
}