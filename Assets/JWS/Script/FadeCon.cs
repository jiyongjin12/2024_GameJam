using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class FadeCon : MonoBehaviour
{
    public static FadeCon instance { get; private set; }

    public Image blockBack;
    public float time = 1.0f;

    public bool flag = false;
    public Sequence sequence;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void FadeInOut()
    {
        if (flag != false) return;

        sequence = DOTween.Sequence().Append(blockBack.DOFade(1.0f, time)).Append(blockBack.DOFade(0.0f, time));
    }


}
