using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    Rigidbody2D body;
    public Transform mouseAnchor;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        if(mouseAnchor != null) {
            transform.position = mouseAnchor.position;
        }
    }

    public void PickupObject(Transform anchorObject) {
        mouseAnchor = anchorObject;
        if(body != null) {
            body.velocity = Vector3.zero;
            body.isKinematic = true;
            body.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }

    public void Drop(Vector2 velocity) {
        mouseAnchor = null;
        if(body != null) {
            body.isKinematic = false;
            body.velocity = velocity;
            body.constraints = RigidbodyConstraints2D.None;
        }
    }
}
