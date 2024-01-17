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
    [SerializeField] private GameObject stageStartPanel;

    [SerializeField] private Image hpGage;

    public float maxHp;
    public float curHp;
    public bool isInGame;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        AudioManager.instance.PlayMusic("Muisc_003");
        curHp = maxHp;
        stageStartPanel.transform.localScale = new Vector3(0, 0, 0);
        stageStartPanel.transform.DOScale(1, 0.3f);
    }

    private void Update()
    {
        hpGage.fillAmount = curHp / maxHp;
    }

    public void HpDown()
    {
        curHp -= 1f;
        if(curHp <= 0f)
        {
            GameOver();
        }
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
        ButtonManager.Instance.RandomMaterial();
        curHp = maxHp;
        stageClearPanel.transform.localScale = new Vector3(0, 0, 0);
        stageClearPanel.transform.DOScale(1, 0.3f);
    }

    public void StageStartButton()
    {
        if (!isInGame) { isInGame = true; }
        stageClearPanel.transform.DOScale(0, 0.3f);
        stageStartPanel.transform.DOScale(0, 0.3f);
        StageManager.instance.NextStageChange();
        TimeManager.instance.StartTimerButton();
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
