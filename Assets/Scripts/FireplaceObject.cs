using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireplaceObject : MonoBehaviour
{
    public enum Type {
        Wood, Starter, Lighter
    }

    public Type type;
    public bool activated = false;

    private void Start()
    {
        GetComponent<Pickup>().OnPickup.AddListener(() =>
        {
            activated = true;
        });
    }
}
