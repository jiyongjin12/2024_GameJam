using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager instance;

    [SerializeField] private TrashData[] trashData;
    [SerializeField] private GameObject trashBase;
    [SerializeField] private Transform spawnPos;
    public List<GameObject> trashList;
    public float waitSpawnTime;

    private void Awake()
    {
        instance = this;
    }

    public GameObject SetTrashObject(bool isClick, Transform basketPos)
    {
        GameObject trashObject = null;
        if (StageManager.instance.nowStageTrash > 1)
        {
            int randomTrash = Random.Range(0, trashData.Length);
            trashObject = Instantiate(trashBase, transform);
            trashObject.GetComponent<Trash>().data = trashData[randomTrash];
            trashObject.transform.position = spawnPos.position;
            StartCoroutine(MoveTrash(trashObject, isClick));
        }
        if (trashList.Count >= 1)
        {
            StartCoroutine(DestroyTrash(trashList[0], isClick, basketPos));
        }
        return trashObject;
    }

    private IEnumerator MoveTrash(GameObject AddGo, bool isClick)
    {
        if(isClick) yield return new WaitForSeconds(0.3f);
        AddGo.transform.DOMove(new Vector3(0, 0, 0), 0.3f);
        yield return new WaitForSeconds(0.3f);
        trashList.Add(AddGo);
    }

    private IEnumerator DestroyTrash(GameObject DestroyGo, bool isClick, Transform basketPos)
    {
        if(!isClick)
        {
            DestroyGo.transform.DOMove(new Vector3(-10, 0, 0), 0.3f);
        }
        else
        {
            Sequence seq = DOTween.Sequence();
            seq.Append(DestroyGo.transform.DOMoveX(basketPos.position.x, 0.2f));
            seq.Append(DestroyGo.transform.DOMoveY(basketPos.position.y, 0.1f));
        }
        
        trashList.RemoveAt(0);
        yield return new WaitForSeconds(0.3f);
        Destroy(DestroyGo);
    }
}