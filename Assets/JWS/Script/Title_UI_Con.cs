using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Title_UI_Con : MonoBehaviour
{
    public Button Play;
    public Button Option;
    public Button End;

    public bool IsButtonON = false;

    


    void Start()
    {
        AudioManager.instance.PlayMusic("Muisc_001");
        Play.onClick.AddListener(OnCStart);
        Option.onClick.AddListener(OnCOption);
        End.onClick.AddListener(OnCEnd);

    }

    void OnCStart()
    {
        if (IsButtonON == true) return;

        IsButtonON = true;
        StartCoroutine(StartButtonFunction());
    }

    IEnumerator StartButtonFunction()
    {
        FadeCon.instance.FadeInOut();
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene("ingame");
    }
    void OnCOption()
    {
        AudioManager.instance.PlaySFX("button");
        AudioManager.instance.AudioOption_On_Off(true);
    }

    void OnCEnd()
    {
        Application.Quit();
    }
}
