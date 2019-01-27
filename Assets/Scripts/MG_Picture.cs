using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MG_Picture : MinigameBase
{
    private bool steady = false;

    public float level;
    public float adjustRate = 0;
    public float timer = 5;

    private int minTilt = 30;
    private int maxTilt = -30;

    public SpriteRenderer feedback;

    public Rigidbody2D rb;

    void Start()
    {
        base.Start();
        rb.MoveRotation(Random.Range(minTilt, maxTilt));
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        //level = transform.eulerAngles.x;
        rb.MoveRotation(rb.rotation + adjustRate * Time.fixedDeltaTime);

        //rb.angularVelocity += adjustRate;

        print(steady);

        if (adjustRate > 0)
        {
            adjustRate -= 0.5f * Time.deltaTime;
        }
        else if (adjustRate < 0)
        {
            adjustRate += 0.5f * Time.deltaTime;
        }

        if (transform.eulerAngles.z > -2 && transform.eulerAngles.z < 2)
        {
            steady = true;
        }
        else
        {
            steady = false;
        }

        if (steady)
        {
            timer -= 1 * Time.deltaTime;
            feedback.color = Color.green;
        }
        else
        {
            timer = 5;
            feedback.color = Color.red;
        }

        if (timer <= 0)
        {
            adjustRate = 0;
            rb.MoveRotation(0);
            CompleteButton.instance.Show();
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
