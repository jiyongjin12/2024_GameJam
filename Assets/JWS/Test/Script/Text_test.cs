using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Text_test : MonoBehaviour
{
    // �ؽ�Ʈ ����� ����ϴ� TextMeshProUGUI ������Ʈ
    public TextMeshProUGUI textCompo;

    // ����� �ؽ�Ʈ���� ������ �迭
    public string[] lines;

    // �ؽ�Ʈ�� ��Ÿ���� �ӵ�
    public float textSpeed;

    // ���� �ؽ�Ʈ �ε���
    private int index;

    // ��ũ��Ʈ�� ������Ʈ�� �� ȣ��Ǵ� �Լ�
    private void Update()
    {
        // �����̽� �� Ű �Է� ����
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // ���� �ؽ�Ʈ�� ������ ��Ÿ������ Ȯ���ϰ� ���� �������� �̵� �Ǵ� ���� ������ ��� ǥ��
            if (textCompo.text == lines[index])
            {
                NextLine();
            }
            else
            {
                // �ؽ�Ʈ Ÿ���� �߿� �����̽� �ٸ� ������ Ÿ������ ���߰� �ش� ������ ��� ǥ��
                StopAllCoroutines();
                textCompo.text = lines[index];
            }
        }
    }

    // ��ũ��Ʈ�� ���۵� �� ȣ��Ǵ� �Լ�
    private void Start()
    {
        // �ʱ⿡�� �ؽ�Ʈ�� ����� ���·� �����ϰ� StartText �Լ� ȣ��
        textCompo.text = string.Empty;
        StartText();
    }

    // �ؽ�Ʈ ��� ���� �Լ�
    void StartText()
    {
        // �ε��� �ʱ�ȭ �� Ÿ���� �ڷ�ƾ ����
        index = 0;
        StartCoroutine(typeline());
    }

    // �ؽ�Ʈ �� ���ھ� ����ϴ� �ڷ�ƾ �Լ�
    IEnumerator typeline()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            // �� ���� ��� �� ���� ���
            AudioManager.instance.PlaySFX("button");
            textCompo.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    // ���� �������� �̵��ϴ� �Լ�
    void NextLine()
    {
        // �ε����� �迭 ���� �̸��� ��� ���� �������� �̵��ϰ� Ÿ���� �ڷ�ƾ �����
        if (index < lines.Length - 1)
        {
            index++;
            textCompo.text = string.Empty;
            StartCoroutine(typeline());
        }
        // �迭 ������ �����ϸ� ���� ������Ʈ�� ��Ȱ��ȭ�Ͽ� �ؽ�Ʈ ��� ����
        else
        {
            gameObject.SetActive(false);
        }
    }
}