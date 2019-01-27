using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CozyMeter : MonoBehaviour
{
    public CozyMeter instance;
    public RectTransform cozinessMeter; 
    float origWidth;
    float currentCoziness;

    // Start is called before the first frame update
    void Start()
    {
        currentCoziness = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 sizeDelta = cozinessMeter.sizeDelta;;
        float currentWidth = origWidth * currentCoziness;
        sizeDelta.x = currentWidth;

        cozinessMeter.sizeDelta = Vector2.Lerp(cozinessMeter.sizeDelta, sizeDelta, Time.deltaTime * 3.0f);
    }
}
