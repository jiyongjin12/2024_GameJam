using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WasteBasket : MonoBehaviour
{ 
    // Button
    public void PutInBasket(TrashMaterial myMaterial)
    {
        if(SpawnManager.instance.trashList.Count > 0)
        {
            if (SpawnManager.instance.trashList[0].GetComponent<Trash>().data.Material == myMaterial)
            {
                
            }
        }
    }

    private void MaterialCheck()
    {

    }

    private void MissionCheck()
    {

    }
}