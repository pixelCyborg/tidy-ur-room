using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractablesBase : MonoBehaviour
{
    private bool isActivated = false;
    private bool minigame;

    private GameObject GM;

    public Collider myCollider;

    public AudioSource mySound;

    public virtual void Start()
    {
        myCollider = GetComponent<Collider>();
        mySound = GetComponent<AudioSource>();
        GM = GameObject.Find("GM");
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Interact();
        }
    }

    public virtual void OnSelected()
    {
        isActivated = true;
    }

    public virtual void Deselect()
    {
        isActivated = false;
    }

    public virtual void Interact()
    {
            // Play animation if exists
            // Play Sound if exists
            // Tell GM to begin minigame
    }
}
