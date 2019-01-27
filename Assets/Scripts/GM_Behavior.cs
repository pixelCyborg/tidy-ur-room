using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GM_Behavior : MonoBehaviour
{

    private int rayDist = 30;

    public Camera Cam;

    private GameObject MG_Cam;
    private GameObject lastInteracted;

    private RaycastHit hit;
    private Ray ray;

    public enum Minigames
    {
        None,
        Dishes,
        Cleaning,
        Picture
    }

    public Minigames currentMG;

    void Start()
    {
        Cam = Camera.main;
        MG_Cam = GameObject.Find("MG Cam");
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
            ray = Cam.ScreenPointToRay(Input.mousePosition);

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
        else if (currentMG == Minigames.Dishes)
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
        else if (currentMG == Minigames.Picture)
        {
            if (Physics.Raycast(ray, out hit, rayDist, 1, QueryTriggerInteraction.Collide))
            {
                if (Input.GetKey(KeyCode.Mouse0))
                {
                    print(hit.collider);

                    //if (hit.collider.tag == "Dishes")
                    //{
                    //    hit.collider.gameObject.SendMessage("Clean");
                    //}
                }
            }
        }
    }

    public void BeginMG(string _MG)
    {
        SceneManager.LoadScene(_MG, LoadSceneMode.Additive);
    }
}
