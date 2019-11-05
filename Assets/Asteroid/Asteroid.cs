using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : Obstacle
{
    protected override void Destruction(GameObject whoDestroy)
    {
        base.Destruction(whoDestroy);

        if (whoDestroy != null)
            whoDestroy.GetComponent<PlayerShip>().Set_Points(Points);
    }
}
