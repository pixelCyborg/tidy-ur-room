using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    public LayerMask navMeshMask;
    NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();   
    }

    //Raycast at the mouse position, grabbing only colliders assigned to the navmesh layer
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit[] hits = Physics.RaycastAll(Camera.main.ScreenPointToRay(Input.mousePosition), 100f, navMeshMask);
            for(int i = 0; i < hits.Length; i++)
            {
                //Set the destination for our agent to go
                agent.SetDestination(hits[i].point);
            }
        }
    }
}
