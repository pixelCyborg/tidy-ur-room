using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM_Behavior : MonoBehaviour
{
    //Create a reference to this object that we can access from anywhere
    public static GM_Behavior instance;

    private int rayDist = 30;

    public Camera Cam;

    public Transform cursorObj;
    private GameObject lastInteracted;

    private RaycastHit hit;
    [HideInInspector]
    public Ray ray;

    public enum Minigames
    {
        None,
        Dishes,
        Cleaning,
        Picture,
        Fireplace
    }

    public Minigames currentMG;

    void Start()
    {
        Cam = Camera.main;
        instance = this;
    }


    void Update()
    {

    }

    void FixedUpdate()
    {
        MonitorMousePos();
    }

    private void MonitorMousePos()
    {
        Debug.DrawLine(ray.origin, ray.GetPoint(rayDist), Color.blue);
        ray = Cam.ScreenPointToRay(Input.mousePosition);

        if (currentMG == Minigames.None)
        {
            if (Physics.Raycast(ray, out hit, rayDist))
            {
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    print(hit.collider);

                    if (lastInteracted)
                    {
                        lastInteracted.SendMessage("Deselect");
                    }

                    lastInteracted = hit.collider.gameObject;
                    lastInteracted.SendMessage("OnSelected");
                }
            }
        }

        if (currentMG == Minigames.Dishes)
        {
            if (Physics.Raycast(ray, out hit, rayDist))
            {
                if (Input.GetKey(KeyCode.Mouse0))
                {
                    print(hit.collider);

                    if (hit.collider.tag == "Dishes")
                    {
                        hit.collider.gameObject.SendMessage("Clean");
                    }
                }
            }
        }
        else if (currentMG== Minigames.Picture)
        {
            
        }
        else if (currentMG==Minigames.Fireplace) {
            if (Physics.Raycast(ray, out hit, rayDist)) {
                if(Input.GetMouseButtonUp(0)) {
                    
                }
            }
        }
    }
}
