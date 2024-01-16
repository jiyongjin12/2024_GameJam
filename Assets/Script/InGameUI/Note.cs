using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Note : MonoBehaviour
{
    [SerializeField] private Image note;
    [SerializeField] private Button onButton;
    [SerializeField] private Button offButton;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            QuestOn(0.3f);
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            QuestOff(0.3f);
        }
    }

    public void QuestOn(float duration) // On
    {
        note.GetComponent<RectTransform>().DOAnchorPosY(0f, duration);

        onButton.gameObject.SetActive(false);
        offButton.gameObject.SetActive(true);
    }

    public void QuestOff(float duration) // Off 
    {
        note.GetComponent<RectTransform>().DOAnchorPosY(400f, duration);

        offButton.gameObject.SetActive(false);
        onButton.gameObject.SetActive(true);
    }
}
