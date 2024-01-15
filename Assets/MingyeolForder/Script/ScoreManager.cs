using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public int YesScore;
    public int NoScore;

    private void Awake()
    {
        instance = this;
    }

    public void Yes()
    {
        YesScore++;
    }

    public void No()
    {
        //Spawn.instance.NoButton();
        NoScore++;
    }
}
