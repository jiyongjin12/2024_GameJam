using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    [SerializeField] private GameObject GoodEffectPrefab;
    [SerializeField] private GameObject BadEffectPrefab;
    [SerializeField] private Transform canvas;

    [SerializeField] private TMP_Text goodText;
    [SerializeField] private TMP_Text badText;

    public int YesScore;
    public int NoScore;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
       goodText.text = YesScore.ToString();
       badText.text = NoScore.ToString();
    }

    public void Yes()
    {
        AudioManager.instance.PlaySFX("YesScore");
        YesScore++;
        Instantiate(GoodEffectPrefab,canvas);
    }

    public void No()
    {
        AudioManager.instance.PlaySFX("NoScore");
        NoScore++;
        Instantiate(BadEffectPrefab, canvas);
        GameManager.instance.HpDown();
    }
}
