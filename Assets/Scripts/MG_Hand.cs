using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MG_Hand : MonoBehaviour
{
    public Camera eventCamera;
    MG_Hand instance;
    Vector2 oldPos = Vector2.zero;
    Pickup currentlyHeldObject;

    private void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveDist = oldPos - (Vector2)transform.position;
        Vector3 origPos = transform.position;
        Vector3 targetPos = eventCamera.ScreenToWorldPoint(Input.mousePosition);
        targetPos.z = origPos.z;
        transform.position = targetPos;

        if(Input.GetMouseButtonDown(0)) {
            Pickup pickup = null;
            RaycastHit2D[] hits = Physics2D.RaycastAll(targetPos, transform.forward, 100f);
            for (int i = 0; i < hits.Length; i++)
            {
                pickup = hits[i].transform.GetComponent<Pickup>();
                if (pickup != null) break;
            }

            if(pickup != null) {
                pickup.PickupObject(transform);
                currentlyHeldObject = pickup;
            }
        }

        if(Input.GetMouseButtonUp(0)) {
            if(currentlyHeldObject != null) {
                currentlyHeldObject.Drop(moveDist * 10f);
                currentlyHeldObject = null;
            }
        }

        oldPos = transform.position;
    }
}
