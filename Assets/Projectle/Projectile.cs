using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : Obstacle
{

    public void Initialize(string tag)
    {
        gameObject.tag = tag;
    }
}
