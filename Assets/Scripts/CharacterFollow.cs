using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class will be set on the camera to follow the player
public class CharacterFollow : MonoBehaviour
{
    //Manually set the target obj to follow
    public Transform target;
    public float lerpSpeed = 5.0f;
    private Vector3 displacement;

    private void Start()
    {
        displacement = target.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, target.position + displacement, Time.deltaTime * lerpSpeed);
    }
}
