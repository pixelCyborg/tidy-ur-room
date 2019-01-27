using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Pickup : MonoBehaviour
{
    public UnityEvent OnPickup;
    Rigidbody2D body;
    Collider2D col;
    public Transform mouseAnchor;

    private void Start()
    {
        col = GetComponent<Collider2D>();
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
            col.enabled = false;
            body.velocity = Vector3.zero;
            body.isKinematic = true;
            body.constraints = RigidbodyConstraints2D.FreezeRotation;
            OnPickup.Invoke();
        }
    }

    public void Drop(Vector2 velocity) {
        mouseAnchor = null;
        if(body != null) {
            col.enabled = true;
            body.isKinematic = false;
            body.velocity = velocity;
            body.constraints = RigidbodyConstraints2D.None;
        }
    }
}
