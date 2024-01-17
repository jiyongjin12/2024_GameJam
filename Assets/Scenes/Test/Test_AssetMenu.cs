using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TrashCategory
{
    General, // 일반
    Plastic, // 페트
    Metal, // 캔류
    Paper // 유리병류
}

[CreateAssetMenu(fileName = "Test_AssetMenu", menuName = "ScriptableObjects/Test_AssetMenu", order = 1)]
public class Test_AssetMenu : ScriptableObject
{
    public ATrash[] trashType;

    [System.Serializable]
    public struct ATrash
    {
        public Sprite categorySprite;
        public TrashCategory trashCategory;
        public int trashNum;
    }
}
