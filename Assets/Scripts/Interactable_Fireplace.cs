using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable_Fireplace : InteractablesBase
{
    public GameObject fire;

    private void Start()
    {
        fire.SetActive(false);
    }

    // When interacted with, start the fire
    public override void Interact()
    {
        base.Interact();
        fire.SetActive(true);
    }
}
