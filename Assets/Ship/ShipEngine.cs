using UnityEngine;
using System;

[RequireComponent(typeof(ShipInput))]
public class ShipEngine : MonoBehaviour
{
    [SerializeField]
    private float speed = 30f;

    private ShipInput shipInput;
    private float lastThrust = float.MinValue;

    public event Action<float> TrustChanged = delegate { };

    private void Awake()
    {
        shipInput = GetComponent<ShipInput>();
    }

    private void Update()
    {
        if (lastThrust != shipInput.Horizontal)
            TrustChanged(shipInput.Horizontal);

        lastThrust = shipInput.Horizontal;

        transform.position += Time.deltaTime * shipInput.Horizontal * transform.right * speed;
    }
}
