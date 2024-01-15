using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Diagnostics.Contracts;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int earthHp;
    [SerializeField] private TMP_Text hpText;
    [SerializeField] private GameObject gameOverImage;
    [SerializeField] private GameObject stageClearPanel;
    [SerializeField] private int earthMaxHp;
    public bool isInGame;

    public int YESscore;
    public int NOscore;


    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        earthHp = earthMaxHp;
        hpText.text = earthHp.ToString();
    }

    public void StartBtn(GameObject go)
    {
        go.gameObject.SetActive(false);
    }

    public void HpMinus()
    {
        earthHp--;
        hpText.text = earthHp.ToString();
        if (earthHp < 1)
        {
            isInGame = false;
            gameOverImage.SetActive(true);
        }
    }

    public void StageClear()
    {
        isInGame = false;
        earthHp = earthMaxHp;
        stageClearPanel.SetActive(true);
    }

    public void StageStart()
    {
        isInGame = true;
        earthHp = earthMaxHp;
        hpText.text = earthHp.ToString();
        stageClearPanel.SetActive(false);
        StageManager.instance.ChangeNextStage();
    }

    public void GameLoadScene()
    {
        SceneManager.LoadScene("Title");
    }
}
