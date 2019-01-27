using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CompleteButton : MonoBehaviour
{
    public static CompleteButton instance;
    CanvasGroup group;

    void Start()
    {
        instance = this;
        group = GetComponent<CanvasGroup>();
        Hide();
    }
    
    public void Show()
    {
        group.alpha = 1;
        group.interactable = true;
        group.blocksRaycasts = true;
        transform.DOPunchScale(transform.localScale * 1.1f, 0.1f, 5, 0.8f);
    } 

    public void Hide()
    {
        group.alpha = 0;
        group.interactable = false;
        group.blocksRaycasts = false;
    }
}
