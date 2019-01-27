using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable_Minigame : InteractablesBase
{
    public GM_Behavior.Minigames minigameMode;
    bool minigameComplete = false;
    public GameObject toggleObject;
    public bool startToggled = false;

    private void Start()
    {
        base.Start();

        if (toggleObject != null)
        {
            toggleObject.SetActive(startToggled ? true : false);
        }
    }

    // When interacted with, start the fire
    public override void Interact()
    {
        if (minigameComplete) return;

        base.Interact();
        minigameComplete = true;
        GM_Behavior.instance.BeginMG(minigameMode);

        if (toggleObject != null)
        {
            toggleObject.SetActive(startToggled ? false : true);
        }
    }
}
