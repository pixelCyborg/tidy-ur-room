using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gunk : MonoBehaviour
{
    private SpriteRenderer image;

    public void Clean() {
        Destroy(gameObject);
    }

    public void Fade(float scrub)
    {
        
    }
}
