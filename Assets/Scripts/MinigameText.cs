using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MinigameText : MonoBehaviour
{
    CanvasGroup group;
    public Text titleText;
    public Text instructionsText;
    public Text cleanedText;
    public static MinigameText instance;
    private bool displayed = false;

    private void Start()
    {
        instance = this;
        group = GetComponent<CanvasGroup>();
        group.DOFade(0.0f, 0.0f);
        cleanedText.enabled = false;
    }

    private void Update()
    {
        if(Input.GetMouseButtonUp(0) && displayed)
        {
            HideInstructions();
        }
    }

    public void MinigameFinished()
    {
        cleanedText.enabled = true;
    }

    public void HideFinishedText()
    {
        Debug.Log("Hiding clean text!");
        cleanedText.enabled = false;
    }

    public void DisplayInstructions(string title, string instructions)
    {
        titleText.text = title;
        instructionsText.text = instructions;
        group.DOFade(1.0f, 0.5f).OnComplete(() => { displayed = true; });
    }

    private void HideInstructions()
    {
        displayed = false;
        group.DOFade(0.0f, 0.5f);
    }
}
