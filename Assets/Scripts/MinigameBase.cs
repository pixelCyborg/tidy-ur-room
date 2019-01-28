using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MinigameBase : MonoBehaviour
{
    public float cleanRate = 29;

    private float MaxDirtiness = 100;
    public float dirtiness = 100;

    public Transform[] stage;


    public GameObject GM;

    public virtual void Start()
    {
        GM = GameObject.Find("GM"); 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Clean gunk that we come into contact with
    }

    public void BeginWash()
    {
        transform.Translate(stage[1].position);
    }

    public void EndWash()
    {
        transform.Translate(stage[2].position);
    }
}
