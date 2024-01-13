using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Trash Data", menuName = "Scriptable Object/Trash Data", order = int.MaxValue)]
public class TrashData : ScriptableObject
{
    [SerializeField]
    private TrashMaterial material;
    public TrashMaterial Material { get { return material; } }
    [SerializeField]
    private TrashColor color;
    public TrashColor Color { get { return color; } }
    [SerializeField]
    private TrashShape shape;
    public TrashShape Shape { get { return shape; } }
    [SerializeField]
    private bool isMark;
    public bool IsMark { get { return isMark; } }
    [SerializeField]
    private Sprite sprite;
    public Sprite Sprite { get { return sprite; } }
}

public enum TrashMaterial {
    General, // 일반
    Plastic, // 페트
    Metal, // 캔류
    Glass // 유리병류
}

public enum TrashShape { 
    Square,
    Triangle,
}

public enum TrashColor {
    Red,
    Blue,
    Green,
}