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

    public GameObject SetTrashObject()
    {
        int randomTrash = Random.Range(0, trashData.Length);
        GameObject trashObject = Instantiate(trashBase, transform);
        trashObject.GetComponent<Trash>().data = trashData[randomTrash];
        trashObject.transform.position = spawnPos.position;
        StartCoroutine(MoveTrash(trashObject));
        if (trashList.Count >= 1)
        {
            StartCoroutine(DestroyTrash(trashList[0]));
        }
        return trashObject;
    }

    private IEnumerator MoveTrash(GameObject AddGo)
    {
        AddGo.transform.DOMove(new Vector3(0, 0, 0), 0.3f);
        yield return new WaitForSeconds(0.3f);
        trashList.Add(AddGo);
    }

    private IEnumerator DestroyTrash(GameObject DestroyGo)
    {
        DestroyGo.transform.DOMove(new Vector3(-10, 0, 0), 0.3f);
        trashList.RemoveAt(0);
        yield return new WaitForSeconds(0.3f);
        Destroy(DestroyGo);
    }
}