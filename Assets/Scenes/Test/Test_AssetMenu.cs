using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TrashCategory
{
    General, // �Ϲ�
    Plastic, // ��Ʈ
    Metal, // ĵ��
    Paper // ��������
}

[CreateAssetMenu(fileName = "Test_AssetMenu", menuName = "ScriptableObjects/Test_AssetMenu", order = 1)]
public class Test_AssetMenu : ScriptableObject
{
    public ATrash[] trashType;

    [System.Serializable]
    public struct ATrash
    {
        public Sprite categorySprite;  // �߰�: �з��� ���� Sprite
        public TrashCategory trashCategory;    // �߰�: �з��� ���� float ��
        public int trashNum;
    }
}
