using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameBase : MonoBehaviour
{
    public float cleanRate = 29;

    private float MaxDirtiness = 100;
    public float dirtiness = 100;

    public GameObject[] dirt;
    public GameObject GM;

    public virtual void Start()
    {
        GM = GameObject.Find("GM"); 
        dirt = GameObject.FindGameObjectsWithTag("Dirt");
    }

    public virtual void Update()
    {
        if (dirtiness <=0)
        {
            GM.SendMessage("DishesDone");
        }
    }

    public virtual void Clean()
    {
        dirtiness -= cleanRate * Time.deltaTime;

        if (dirtiness < MaxDirtiness /dirt.Length)
        {
            dirt[0].SetActive(false);
        }
    }
}
