using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ShowButton : MonoBehaviour
{
    public Button[] buttons;
    public Image timeGauge;

    [SerializeField] private Image Stagetime;
    [SerializeField] private float currentTime;

    private void Start()
    {
        SelectButton(0);
        TimeImage();
        StartCoroutine(C_stageTime());
    }

    private void Update()
    {
        Stagetime.fillAmount = currentTime;
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
        timeGauge.rectTransform.DOAnchorPosY(523f, .5f);
    }

    public IEnumerator C_stageTime()
    {
        while(currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            yield return null;
        }
        if (currentTime < 0)
        {
            //gameOver
        }
    }


}