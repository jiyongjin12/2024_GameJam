using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class TrashCheckBasket : MonoBehaviour
{
    public TrashMaterial material;

    public void BasketCheck()
    {
        if (SpawnManager.instance.trashList.Count > 0)
        {
            TimeManager.instance.TimeSet();
            if (SpawnManager.instance.trashList[0].GetComponent<Trash>().data.Material == material)
            {
                Debug.Log("Great");
            }
            else
            {
                Debug.Log("Bad");
                GameManager.instance.HpMinus();
            }
            SpawnManager.instance.SetTrashObject(true, transform);
            StageManager.instance.TrashAmountDown();
        }
    }
}
