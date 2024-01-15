using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public static StageManager instance;

    [SerializeField] private TMP_Text trashMountText;
    public GameObject[] pipes;

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
        if(stageNum == 0) pipes[0].SetActive(true);
        else if(stageNum == 1) pipes[1].SetActive(true);
        else if (stageNum == 2) pipes[2].SetActive(true);
        else if (stageNum == 3) pipes[3].SetActive(true);
        MissionManager.instance.RandomMaterial();nowStageTrash = stageTrashAmount[stageNum];
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