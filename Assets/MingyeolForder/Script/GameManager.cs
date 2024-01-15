using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Diagnostics.Contracts;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private GameObject gameOverImage;
    [SerializeField] private GameObject stageClearPanel;
    public bool isInGame;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        StageClear();
    }

    public void GameOver()
    {
        if (isInGame)
        {
            isInGame = false;
            gameOverImage.transform.DOScale(1, 0.3f);
        }
    }

    public void StageClear()
    {
        if(isInGame) { isInGame = false;}

        stageClearPanel.transform.localScale = new Vector3(0, 0, 0);
        stageClearPanel.transform.DOScale(1, 0.3f);
    }

    public void StageStartButton()
    {
        if (!isInGame) { isInGame = true; }
        stageClearPanel.transform.DOScale(0, 0.3f);
        TimeManager.instance.StartTimerButton();
    }
}
