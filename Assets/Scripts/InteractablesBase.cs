using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractablesBase : MonoBehaviour
{
    private bool isActivated = false;
    private bool isFinished = false;
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
        print("Active!");
    }

    public virtual void Deselect()
    {
        isActivated = false;
        print("Deactivated");
    }

    public virtual void Interact()
    {
        // Play animation if exists
        // Play Sound if exists
        if (mySound.clip)
        {
            mySound.Play();
        }
    }
}
