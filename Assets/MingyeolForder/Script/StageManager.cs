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
        TrashInit();
    }

    public void TrashDown()
    {
        nowStageTrash--;
        if(nowStageTrash <= -2)
        {
            Debug.Log("dddd");
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
        nowStageTrash = (stage[nowStageNum].trashAmount + 3);
    }

    
}