using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DotTest : MonoBehaviour
{
    //public GameObject note;
    //public bool show;

    //void Start()
    //{
    //    show = false;
    //    //note.transform.DOMove(new Vector3(5, 0, 0), 1);
    //    //note.transform.DOLocalMoveY(-5, 1f).SetRelative();
    //}

    //void Update()
    //{
    //    OpenNote();
    //}

    //void OpenNote()
    //{
    //    if (show)
    //    {
    //        note.transform.DOMoveY(3.5f, 1f);
    //    }
    //    else
    //    {
    //        note.transform.DOMoveY(7, 1f);
    //    }
    //}

    //public void IsOnClick()
    //{
    //    show = true;
    //}

    //public void IsOffClick()
    //{
    //    show = false;
    //}

    // Start is called before the first frame update
    void Start()
    {
        DOTween.Init();
        // transform �� scale ���� ��� 0.1f�� �����մϴ�.
        transform.localScale = Vector3.one * 0.1f;
        // ��ü�� ��Ȱ��ȭ �մϴ�.
        gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);

        // DOTween �Լ��� ���ʴ�� �����ϰ� ���ݴϴ�.
        var seq = DOTween.Sequence();

        // DOScale �� ù ��° �Ķ���ʹ� ��ǥ Scale ��, �� ��°�� �ð��Դϴ�.
        seq.Append(transform.DOScale(1.1f, 0.2f));
        seq.Append(transform.DOScale(1f, 0.1f));

        seq.Play();
    }

    public void Hide()
    {
        var seq = DOTween.Sequence();

        transform.localScale = Vector3.one * 0.2f;

        seq.Append(transform.DOScale(1.1f, 0.1f));
        seq.Append(transform.DOScale(0.2f, 0.2f));

        // OnComplete �� seq �� ������ �ִϸ��̼��� �÷��̰� �Ϸ�Ǹ�
        // { } �ȿ� �ִ� �ڵ尡 ����ȴٴ� �ǹ��Դϴ�.
        // ���⼭�� �ݱ� �ִϸ��̼��� �Ϸ�� �� ��ÿ�� ��Ȱ��ȭ �մϴ�.
        seq.Play().OnComplete(() =>
        {
            gameObject.SetActive(false);
        });
    }
}
