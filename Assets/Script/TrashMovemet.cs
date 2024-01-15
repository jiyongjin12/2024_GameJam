using System.Collections;
using System.Collections.Generic;
using UnityEngine.Rendering;
using UnityEngine;
using DG.Tweening;

public class TrashMovemet : MonoBehaviour
{
    public GameObject summonedTrash;
    public List<GameObject> trashList;
    public GameObject spawnPos;

    private bool canSummon = true;

    public void Start()
    {
        SummonTrash(3);
    }

    private void SummonTrash(int count)
    {
        for (int i = 0; i < count; i++)
        {
            GameObject trash = Instantiate(summonedTrash, spawnPos.transform.position, Quaternion.identity);
            trashList.Add(trash);
        }
    }

    private void Update()
    {
        trashList.RemoveAll(item => item == null);

        if (trashList.Count < 3 && canSummon)
        {
            Invoke("SummonTrashAfterDelay", 0.3f);
            canSummon = false;
        }

        

        ObjectInformationInLinst();
    }

    private void ObjectInformationInLinst()
    {
        if (trashList.Count > 0 && trashList[0] != null && trashList[0].transform.position.z != 0)
        {
            trashList[0].transform.DOLocalMove(new Vector3(0, .4f, 0f), 1f);
            trashList[0].transform.DOScale(new Vector3(1.8f, 2.7f, 1), 1f);
            //trashList[0].GetComponent<Renderer>().material.DOColor(new Color(255, 255, 255), 1.0f);
        }
        if (trashList.Count > 0 && trashList[1] != null && trashList[1].transform.position.z != 0.1f)
        {
            trashList[1].transform.DOLocalMove(new Vector3(0, 1.1f, 0.1f), 1f);
            trashList[1].transform.DOScale(new Vector3(1.3f, 2, 1), 1f);
            //trashList[1].GetComponent<Renderer>().material.DOColor(new Color(150, 150, 150), 1.0f);
        }
    }

    private void SummonTrashAfterDelay()
    {
        GameObject trash = Instantiate(summonedTrash, spawnPos.transform.position, Quaternion.identity);
        trashList.Add(trash);

        canSummon = true;
    }
}
