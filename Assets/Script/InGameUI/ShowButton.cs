using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ShowButton : MonoBehaviour
{
    public Button[] buttons;
    public Image timeGaugeObj;

    [SerializeField] private Image timeGauge;
    [SerializeField] private float currentTime;
    private float maxCurrentTime;

    private void Start()
    {
        SelectButton(0);
        TimeImage();
        maxCurrentTime = currentTime;
    }

    private void Update()
    {
        TimeCount();
    }

    private void SelectButton(int startIndex)
    {
        // �迭 ����
        if (startIndex >= buttons.Length)
        {
            return;
        }

        // ���� �ִ� ������ ���� ����
        buttons[startIndex].GetComponent<RectTransform>().DOAnchorPosY(-450f, .3f)
            .OnComplete(() => SelectButton(startIndex + 1));
    }

    private void TimeImage()
    {
        timeGaugeObj.rectTransform.DOAnchorPosY(0, .5f);
    }

    private void TimeCount()
    {
        currentTime -= Time.deltaTime;
        currentTime = Mathf.Max(0f, currentTime);
        timeGauge.fillAmount = currentTime / maxCurrentTime;
    }
}