using System;

using TMPro;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class Stage
{
    public int trashAmount;
    public float stageTime;
}

public class StageManager : MonoBehaviour
{
    public static StageManager instance;

    [SerializeField] private TMP_Text trashMountText;

    public Stage[] stage;
    public int nowStageNum;
    public int nowStageTrash;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        nowStageNum = 0;
        TrashInit();
    }

    public void TrashDown()
    {
        nowStageTrash--;
        if(nowStageTrash <= 0)
        {
            GameManager.instance.StageClear();
        }
    }

    public void NextStageChange()
    {
        nowStageNum++;
        TrashInit();
    }

    public void TrashInit()
    {
        nowStageTrash = stage[nowStageNum].trashAmount;
    }

    
}