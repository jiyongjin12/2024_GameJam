using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Text_test : MonoBehaviour
{
    // 텍스트 출력을 담당하는 TextMeshProUGUI 컴포넌트
    public TextMeshProUGUI textCompo;

    // 출력할 텍스트들을 저장한 배열
    public string[] lines;

    // 텍스트가 나타나는 속도
    public float textSpeed;

    // 현재 텍스트 인덱스
    private int index;

    // 스크립트가 업데이트될 때 호출되는 함수
    private void Update()
    {
        // 스페이스 바 키 입력 감지
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // 현재 텍스트가 완전히 나타났는지 확인하고 다음 라인으로 이동 또는 현재 라인을 즉시 표시
            if (textCompo.text == lines[index])
            {
                NextLine();
            }
            else
            {
                // 텍스트 타이핑 중에 스페이스 바를 누르면 타이핑을 멈추고 해당 라인을 즉시 표시
                StopAllCoroutines();
                textCompo.text = lines[index];
            }
        }
    }

    // 스크립트가 시작될 때 호출되는 함수
    private void Start()
    {
        // 초기에는 텍스트를 비워둔 상태로 시작하고 StartText 함수 호출
        textCompo.text = string.Empty;
        StartText();
    }

    // 텍스트 출력 시작 함수
    void StartText()
    {
        // 인덱스 초기화 후 타이핑 코루틴 시작
        index = 0;
        StartCoroutine(typeline());
    }

    // 텍스트 한 글자씩 출력하는 코루틴 함수
    IEnumerator typeline()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            // 각 글자 출력 시 사운드 재생
            AudioManager.instance.PlaySFX("button");
            textCompo.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    // 다음 라인으로 이동하는 함수
    void NextLine()
    {
        // 인덱스가 배열 길이 미만인 경우 다음 라인으로 이동하고 타이핑 코루틴 재시작
        if (index < lines.Length - 1)
        {
            index++;
            textCompo.text = string.Empty;
            StartCoroutine(typeline());
        }
        // 배열 끝까지 도달하면 게임 오브젝트를 비활성화하여 텍스트 출력 종료
        else
        {
            gameObject.SetActive(false);
        }
    }
}