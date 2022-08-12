using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void OnCollisionEnter(Collision other);

public delegate void OnTriggerEnter(Collider other);

public class BodyComponent : MonoBehaviour
{
    public event OnCollisionEnter OnBodyEnterCollision;
    public event OnTriggerEnter OnBodyEnterTrigger;

    private void OnCollisionEnter(Collision collision)
    {
        OnBodyEnterCollision?.Invoke(collision);
    }

    private void OnTriggerEnter(Collider other)
    {
        OnBodyEnterTrigger?.Invoke(other);
    }
}
