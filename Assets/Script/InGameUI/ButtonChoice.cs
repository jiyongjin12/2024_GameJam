using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ButtonChoice : MonoBehaviour
{
    public Button[] buttons;

    private void Start()
    {
        MoveButtonsSequentially(0);
    }

    private void MoveButtonsSequentially(int startIndex)
    {
        // 배열 지정
        if (startIndex >= buttons.Length)
        {
            return;
        }

        // 현제 에니 수행후 다음 실행
        buttons[startIndex].GetComponent<RectTransform>().DOAnchorPosY(-430f, .3f)
            .OnComplete(() => MoveButtonsSequentially(startIndex + 1));
    }
}