using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [SerializeField]
    private Text Points;

    [SerializeField]
    private Slider Health;

    public void Initialize(int life)
    {
        Health.maxValue = life;
        Health.value = Health.maxValue;
    }

    public void UpdateHealth(int life)
    {
        Health.value = life;
    }

    public void UpdatePoints(int points)
    {
        Points.text = points.ToString();
    }
}
