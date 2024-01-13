using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameScene : MonoBehaviour
{
    public void hidingBtn(GameObject go)
    {
        go.gameObject.SetActive(false);
    }
}
