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
        // �迭 ����
        if (startIndex >= buttons.Length)
        {
            return;
        }

        // ���� ���� ������ ���� ����
        buttons[startIndex].GetComponent<RectTransform>().DOAnchorPosY(-430f, .3f)
            .OnComplete(() => MoveButtonsSequentially(startIndex + 1));
    }
}