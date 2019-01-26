using UnityEngine;
using System.Collections;

public class CandleFlickerBehavior : MonoBehaviour
{
    private bool done;
    private float duration;
    private float brightness1;
    private float brightness2;
    private float startTime;
    public Light lt;


    void Start()
    {
        lt = GetComponent<Light>();
        duration = Random.Range(0.2f, 1.0f);
        brightness1 = Random.Range(0.5f, 1.0f);
        startTime = Time.time;
        brightness2 = Random.Range(1.0f, 1.7f);

    }

    void Update()
    {
        float t = (Time.time - startTime) /duration;

        if (lt.intensity == brightness2)
        {
            done = true;
            Flicker();
        }

        lt.intensity = Mathf.Lerp(brightness1, brightness2, t);

        //float phi = Time.time / duration * 2 * Mathf.PI;
        //float amplitude = Mathf.Cos(phi) * brightness1 + brightness2;
    }

    private void Flicker()
    {
        done = false;
        duration = Random.Range(0.8f, 1.96f);
        brightness1 = brightness2;
        startTime = Time.time;
        brightness2 = Random.Range(0.5f, 2.0f);
    }
}
