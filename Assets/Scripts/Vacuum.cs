using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vacuum : MonoBehaviour
{
    int gunkCount = 0;

    //Get a count of all the gunk on the screen
    private void Start()
    {
        gunkCount = FindObjectsOfType<Gunk>().Length;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Clean gunk that we come into contact with
        Gunk gunk = collision.transform.GetComponent<Gunk>();
        if (gunk == null) return;

        gunk.Clean();
        gunkCount--;
        if(gunkCount <= 0)
        {
            Debug.Log("Minigame complete!");
            //The games been won!
            CompleteButton.instance.Show();
        }
    }
}
