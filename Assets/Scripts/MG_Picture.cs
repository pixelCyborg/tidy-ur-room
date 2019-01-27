using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MG_Picture : MinigameBase
{
    public float level;
    public float adjustRate = 0;

    private int minTilt = 60;
    private int maxTilt = 120;

    public Collider left;
    public Collider right;

    void Start()
    {
        base.Start();
        //level = Random.Range(minTilt, maxTilt);
    }


    void Update()
    {
        if (transform.eulerAngles.x < minTilt)
        {
            Vector3 targetRot = transform.rotation.eulerAngles;
            targetRot = new Vector3(minTilt, transform.rotation.y, transform.rotation.z);
            transform.rotation = Quaternion.Euler(targetRot);
            adjustRate = 0;
        }
        else if (transform.eulerAngles.x > maxTilt)
        {
            Vector3 targetRot = new Vector3(maxTilt, transform.rotation.y, transform.rotation.z);
            targetRot.x = maxTilt;
            transform.rotation = Quaternion.Euler(targetRot);
            adjustRate = 0;
        }
        else
        {
            Vector3 targetRot = transform.rotation.eulerAngles;
            targetRot.x = level + adjustRate * Time.deltaTime;
            transform.rotation = Quaternion.Euler(targetRot);
        }
    }

    public void LeftTilt()
    {
        adjustRate -= 2.5f;
    }
    public void RightTilt()
    {
        adjustRate += 2.5f;
    }
}
