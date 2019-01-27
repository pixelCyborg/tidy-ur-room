using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable_LightSource : InteractablesBase
{
    Light[] lights;

    void Start() {
        lights = GetComponentsInChildren<Light>();
        for (int i = 0; i < lights.Length; i++) {
            lights[i].enabled = false;
        }
    }

    // Start is called before the first frame update
    public override void Interact()
    {
        base.Interact();
        for (int i = 0; i < lights.Length; i++) {
            lights[i].enabled = true;
        }
    }
}
