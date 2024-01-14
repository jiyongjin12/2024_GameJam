using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Text_test : MonoBehaviour
{
    public TextMeshProUGUI textCompo;
    public string[] lines;
    public float textSpeed;

    private int index;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(textCompo.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textCompo.text = lines[index];
            }
        }
    }

    private void Start()
    {
        
        textCompo.text = string.Empty;
        StartText();
    }

    void StartText()
    {
        index = 0;
        StartCoroutine(typeline());
    }

    IEnumerator typeline()
    {
        foreach(char c in lines[index].ToCharArray())
        {
            AudioManager.instance.PlaySFX("button");
            textCompo.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textCompo.text = string.Empty;
            StartCoroutine(typeline());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}