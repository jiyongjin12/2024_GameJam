using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConverCon : MonoBehaviour
{
    public GameObject TextPanel;

    void Start()
    {
        StartCoroutine(StartText());
    }


    IEnumerator StartText()
    {
        yield return new WaitForSeconds(1.0f);
        TextPanel.gameObject.SetActive(true);
    }
}
