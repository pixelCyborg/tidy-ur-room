using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM_Behavior : MonoBehaviour
{
    public Camera Cam;

    void Start()
    {
        
    }


    void Update()
    {
            RaycastHit hit ;
            Ray ray = Cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100.0f ))
            {
                print(hit.collider);
                Debug.DrawLine(ray.origin, ray.GetPoint(100), Color.blue);

            }
    }
}
