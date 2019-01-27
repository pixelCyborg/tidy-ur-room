using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CozyMeter : MonoBehaviour
{
    public static CozyMeter instance;
    public RectTransform cozinessMeter;
    public Text text;
    float origWidth;
    float currentCoziness;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        currentCoziness = 0;
        origWidth = cozinessMeter.sizeDelta.x;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 sizeDelta = cozinessMeter.sizeDelta;;
        float currentWidth = origWidth * currentCoziness;
        sizeDelta.x = currentWidth;

        cozinessMeter.sizeDelta = Vector2.Lerp(cozinessMeter.sizeDelta, sizeDelta, Time.deltaTime * 3.0f);
        text.text = "COZINESS: " + (currentCoziness * 100.0f) + "%";
    }

    public void AddMeter(float percentage) {
        currentCoziness += percentage * 0.01f;
    }
}
