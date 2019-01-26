using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Just a simple script to enable/disable a wall for "occlusion"
public class Wall : MonoBehaviour
{
    private Renderer renderer;

    private void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Occluder") {
            renderer.enabled = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Occluder") {
            renderer.enabled = true;
        }
    }
}
