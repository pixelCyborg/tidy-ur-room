﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireplace : MonoBehaviour
{
    ParticleSystem fireParticles;
    int ingredients = 0;

    void Start() {
        fireParticles = GetComponentInChildren<ParticleSystem>();
        fireParticles.Stop();
    }

    public void OnTriggerEnter2D(Collider2D collider) {
        FireplaceObject obj = collider.transform.GetComponent<FireplaceObject>();
        if (obj.activated == false) return;
        if(obj != null) {
            switch(obj.type) {
                case FireplaceObject.Type.Wood:
                    break;
                case FireplaceObject.Type.Starter:
                    break;
                case FireplaceObject.Type.Lighter:
                    break;
            }
        }

        ingredients++;
        //Destroy(obj.gameObject);
        Destroy(obj.GetComponent<Pickup>());
        Destroy(obj);
        if(ingredients >= 3) {
            Light();
            CompleteButton.instance.Show();
        }
    }

    private void Light() {
        fireParticles.Play();
    }
}
