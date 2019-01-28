using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DishLoader : MonoBehaviour
{
    private int dishesDone;

    void Start()
    {
        
    }


    void Update()
    {

        CompleteButton.instance.Show();

    }

    public void DishDone()
    {
        dishesDone++;

    }
}
