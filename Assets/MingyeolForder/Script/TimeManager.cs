using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Transactions;
using DG.Tweening.Core.Easing;

public class TimeManager : MonoBehaviour
{
    public static TimeManager instance;

    [SerializeField] private Image timeImage;

    [SerializeField] private Image stageTimeImage;
    public float currStageTime;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        stageTimeImage.fillAmount = currStageTime / StageManager.instance.stage[StageManager.instance.nowStageNum].stageTime;
    }

    private void Start()
    {
        TimeSet();
    }

    public void TimeSet()
    {
        currStageTime = StageManager.instance.stage[StageManager.instance.nowStageNum].stageTime;
    }

    public void StartTimerButton()
    {
        TimeSet();
        if (StageManager.instance.nowStageTrash > 0)
        { 
            StartCoroutine(Co_TimeCheck());
        }
    }
    
    public IEnumerator Co_TimeCheck()
    {
        while (currStageTime > 0 && GameManager.instance.isInGame)
        {
            currStageTime -= Time.deltaTime;
            yield return null;
        }
        if(currStageTime < 0)
        {
            GameManager.instance.GameOver();
        }
    }
}
