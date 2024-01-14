using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCheckManager : MonoBehaviour
{
    public void BasketCheck(int materialInBasket)
    {
        if (SpawnManager.instance.trashList.Count > 0)
        {
            TimeManager.instance.TimeSet();
            if ((int)SpawnManager.instance.trashList[0].GetComponent<Trash>().data.Material == materialInBasket)
            {
                Debug.Log("Great");
            }
            else
            {
                Debug.Log("Bad");
                GameManager.instance.HpMinus();
            }
            SpawnManager.instance.SetTrashObject();
            StageManager.instance.TrashAmountDown();
        }
    }
}
