using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ShowButton : MonoBehaviour
{
    public Button[] buttons;
    public Image timeGauge;

    private void Start()
    {
        SelectButton(0);
        TimeImage();
    }

    private void SelectButton(int startIndex)
    {
        // 배열 지정
        if (startIndex >= buttons.Length)
        {
            return;
        }

        // 현제 에니 수행후 다음 실행
        buttons[startIndex].GetComponent<RectTransform>().DOAnchorPosY(-450f, .3f)
            .OnComplete(() => SelectButton(startIndex + 1));
    }

    private void TimeImage()
    {
        timeGauge.rectTransform.DOAnchorPosY(470f, .5f);
    }


}