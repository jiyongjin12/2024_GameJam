using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionManager : MonoBehaviour
{

    public static MissionManager instance; 
    bool[] bools = new bool[4] { false, false, false, false };
    TrashMaterial trashMaterial;
    int randomNum;

    [SerializeField] private GameObject[] ImagePanel;
    [SerializeField] private Image[] materialImage;
    [SerializeField] private Image[] materialColor;
    [SerializeField] private Sprite[] sprites;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {

        RandomMaterial();
    }

  public void RandomMaterial()
    {
        for( int i = 0; i < StageManager.instance.pipes.Length; i++)
        {
            if (StageManager.instance.pipes[i].activeSelf)
            {

                do
                {
                    randomNum = Random.Range(0, 4);
                } while (bools[randomNum] == true);
               

                bools[randomNum] = true;

                switch (randomNum) {
                    case 0: trashMaterial = TrashMaterial.General; break;
                    case 1: trashMaterial = TrashMaterial.Plastic; break;
                    case 2: trashMaterial = TrashMaterial.Metal; break;
                    case 3: trashMaterial = TrashMaterial.Paper; break;
                }

                StageManager.instance.pipes[i].GetComponent<TrashCheckBasket>().material = trashMaterial;

                ImagePanel[i].gameObject.SetActive(true);
                materialImage[i].sprite = sprites[randomNum];
            }
        }
    }
}