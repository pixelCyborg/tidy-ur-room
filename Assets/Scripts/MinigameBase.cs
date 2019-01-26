using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameBase : MonoBehaviour
{
    private GameObject[] dirt;
    public virtual void OnAwake()
    {
        dirt = GameObject.FindGameObjectsWithTag("dirt");
    }

    public virtual void Update()
    {
        
    }

    public virtual void Clean()
    {

    }
}
