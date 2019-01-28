using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class EndText : MonoBehaviour
{
    public static EndText instance;
    CanvasGroup group;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        group = GetComponent<CanvasGroup>();
        group.alpha = 0;
        group.interactable = false;
        group.blocksRaycasts = false;
    }

    // Update is called once per frame
    public void ShowEndText() {
        group.DOFade(1.0f, 1.0f);
    }
}
