using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int earthHp;
    [SerializeField] private TMP_Text hpText;
    [SerializeField] private GameObject gameOverImage;
    [SerializeField] private GameObject stageClearPanel;
    [SerializeField] private int earthMaxHp;
    public bool isInGame;

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
        stageClearPanel.SetActive(true);
    }

    public void GameLoadScene()
    {
        SceneManager.LoadScene("Title");
    }
}
