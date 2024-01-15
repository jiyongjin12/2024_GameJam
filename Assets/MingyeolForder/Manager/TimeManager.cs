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
    [SerializeField] private float maxTime;
    public float curTime;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        timeImage.fillAmount = curTime / maxTime;
    }

    private void Start()
    {
        TimeSet();
    }

    public void TimeSet()
    {

        curTime = maxTime;
    }

    public void TimerButton()
    {
        GameManager.instance.isInGame = true;
        SpawnManager.instance.SetTrashObject(false, null);
        StartCoroutine(Co_TimeCheck());
    }

    public void StartTimer()
    {
        if(GameManager.instance.isInGame)
        {
            if (StageManager.instance.nowStageTrash > 0)
            {
                StageManager.instance.TrashAmountDown();
                StartCoroutine(Co_TimeCheck());
            }
            else
            {
                StartCoroutine(Co_TimeCheck());
            }
        }
    }
    
    public IEnumerator Co_TimeCheck()
    {
        if(GameManager.instance.isInGame)
        {
            TimeSet();
            while (curTime > 0 && GameManager.instance.isInGame)
            {
                curTime -= Time.deltaTime;
                yield return null;
            }
            if (curTime < 0)
            {
                StartTimer();
                GameManager.instance.HpMinus();
                SpawnManager.instance.SetTrashObject(false, null);
            }
        }
    }
}
