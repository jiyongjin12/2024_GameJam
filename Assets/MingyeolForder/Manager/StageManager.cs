using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public static StageManager instance;

    [SerializeField] private TMP_Text trashMountText;

    public int[] stageTrashAmount;
    public int stageNum;
    public int nowStageTrash;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        stageNum = -1;
        nowStageTrash = ChangeNextStage();
    }

    private void Update()
    {
        trashMountText.text = nowStageTrash.ToString();
    }

    public int ChangeNextStage()
    {
        stageNum++;
        return stageTrashAmount[stageNum];
    }

    public void TrashAmountDown()
    {
        nowStageTrash--;
        if(nowStageTrash < 1)
        {
            TimeManager.instance.curTime = 0;
            GameManager.instance.StageClear();
        }
    }
}