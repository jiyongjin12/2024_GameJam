using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class AI_Con : MonoBehaviour
{
    public Text_test IsConver;
    Animator anim;
    // Start is called before the first frame update

    // Update is called once per frame

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        if(IsConver.converOver == true)
        {
            anim.SetBool("CONVEROVER", true);
            StartCoroutine(moveNextScene());
        }
    }

    IEnumerator moveNextScene()
    {
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene("InGame");
    }
}
