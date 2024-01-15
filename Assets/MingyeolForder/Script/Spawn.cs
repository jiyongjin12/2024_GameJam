using System.Collections;
using System.Collections.Generic;
using UnityEngine.Rendering;
using UnityEngine;
using DG.Tweening;

public class Spawn : MonoBehaviour
{
    public static Spawn instance;

    [SerializeField] private TrashData[] datas;
    public GameObject summonedTrash;
    public List<GameObject> trashList;
    public GameObject spawnPos;
    public bool click;

    private bool canSummon = true;

    private void Awake()
    {
        instance = this;
    }

    public void Start()
    {
        click = true;
        SummonTrash(3);
    }

    private void TrashSpawn()
    {
        if (StageManager.instance.nowStageTrash > 0)
        {
            
            GameObject trash = Instantiate(summonedTrash, spawnPos.transform.position, Quaternion.identity);
            trash.GetComponent<Trash>().data = datas[Random.Range(0, datas.Length)];
            trashList.Add(trash);
            StageManager.instance.TrashDown();
        }
        else canSummon = false;
    }
    private void SummonTrash(int count)
    {
        for (int i = 0; i < count; i++)
        {
            TrashSpawn();
        }
    }

    private void Update()
    {
        trashList.RemoveAll(item => item == null);

        if (trashList.Count < 3 && canSummon)
        {
            Invoke("SummonTrashAfterDelay", .1f);
            canSummon = false;
        }

        ObjectInformationInLinst();
    }

    //private void ObjectInformationInLinst()
    //{
    //    if (trashList.Count > 0 && trashList[0] != null && trashList[0].transform.position.z != 0)
    //    {
    //        trashList[0].transform.DOLocalMove(new Vector3(0, .4f, 0f), 1f);
    //        trashList[0].transform.DOScale(new Vector3(1.8f, 2.7f, 1), 1f);
    //        //trashList[0].GetComponent<Renderer>().material.DOColor(new Color(255, 255, 255), 1.0f);
    //    }
    //    if (trashList.Count > 0 && trashList[1] != null && trashList[1].transform.position.z != 0.1f)
    //    {
    //        trashList[1].transform.DOLocalMove(new Vector3(0, 1.1f, 0.1f), 1f);
    //        trashList[1].transform.DOScale(new Vector3(1.3f, 2, 1), 1f);
    //        //trashList[1].GetComponent<Renderer>().material.DOColor(new Color(150, 150, 150), 1.0f);
    //    }
    //}

    private void ObjectInformationInLinst()
    {
        if (trashList.Count > 0 && trashList[0] != null && trashList[0].transform.position.z != 0)
        {
            TweenTrash(trashList[0], new Vector3(0, -.8f, 0f), new Vector3(1.8f, 2.2f, 1), .5f);
        }
        if (trashList.Count > 1 && trashList[1] != null && trashList[1].transform.position.z != .1f)
        {
            TweenTrash(trashList[1], new Vector3(0, -.23f, .1f), new Vector3(1.3f, 1.7f, 1), 1f);
        }
    }

    private void TweenTrash(GameObject trashObject, Vector3 targetPosition, Vector3 targetScale, float duration)
    {
        if (trashObject != null)
        {
            trashObject.transform.DOLocalMove(targetPosition, duration);
            trashObject.transform.DOScale(targetScale, duration);
        }
    }

    private void SummonTrashAfterDelay()
    {
        TrashSpawn();

        canSummon = true;
    }

    private void RemoveList()
    {
        trashList.RemoveAt(0);
    }

    // 밑에는 지워도 되는것_ 버튼눌렀을때 좌우 있어보이게 눈속임 한것
    public void YesButton()
    {
        if (trashList.Count > 0 && click)
        {
            TimeManager.instance.TimeSet();
            click = false;
            GameObject gameObj = trashList[0].gameObject;
            RemoveList();
            gameObj.transform.DOMoveX(30, 1f).SetRelative();
            StartCoroutine(Co_Destory(gameObj, 1f));
            StartCoroutine(ClickTime());
        }
    }

    public void NoButton()
    {
        if (trashList.Count > 0 && click)
        {
            TimeManager.instance.TimeSet();
            click = false;
            GameObject gameObj = trashList[0].gameObject;
            RemoveList();
            gameObj.transform.DOMoveX(-30, 1f).SetRelative();
            StartCoroutine(Co_Destory(gameObj, 1f));
            StartCoroutine(ClickTime()); 
        }
    }

    public IEnumerator ColorButton(Transform transform)
    {
        if (trashList.Count > 0 && click)
        {
            click = false;
            
            GameObject gameObj = trashList[0].gameObject;
            RemoveList();
            Sequence seq = DOTween.Sequence();
            seq.Append(gameObj.transform.DOMoveX(transform.position.x, 0.5f));
            seq.Append(gameObj.transform.DOMoveY(transform.position.y, 0.3f));
            yield return new WaitForSeconds(0.5f);
            click = true;
            StartCoroutine(Co_Destory(gameObj, 1f));
        }
    }

    private IEnumerator Co_Destory(GameObject go, float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Destroy(go);
    }

    private IEnumerator ClickTime()
    {
        yield return new WaitForSeconds(0.5f);
        click = true;
    }
}
