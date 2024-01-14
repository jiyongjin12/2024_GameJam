using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class OnButton : MonoBehaviour
{
    public DotTest dotween;

    public void OnButtonClick()
    {
        var seq = DOTween.Sequence();

        seq.Append(transform.DOScale(0.95f, 0.1f));
        seq.Append(transform.DOScale(1.05f, 0.1f));
        seq.Append(transform.DOScale(1f, 0.1f));

        seq.Play().OnComplete(() => {
            dotween.Hide();
        });
    }
}
