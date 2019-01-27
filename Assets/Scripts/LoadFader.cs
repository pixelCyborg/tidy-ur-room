using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class LoadFader : MonoBehaviour
{
    public static LoadFader instance;
    Image image;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        instance = this;
        image.DOFade(0.0f, 0.0f);
    }

    // Update is called once per frame
    public void FadeIn(System.Action callback = null)
    {
        image.DOFade(1.0f, 1.0f).OnComplete(() => { if(callback != null) callback(); }); ;
    }

    public void FadeOut()
    {
        image.DOFade(0.0f, 0.5f);
    }
}
