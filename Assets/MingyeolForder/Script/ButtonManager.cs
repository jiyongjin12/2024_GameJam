using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private GameObject[] colorButtons;

    [SerializeField] private GameObject destroyButton;
    [SerializeField] private GameObject resycleButton;

    [SerializeField] private Image[] materialImage;
    [SerializeField] private Sprite[] materialSprite;

    private void Awake()
    {
        RandomMaterial();
    }
    private void Start()
    {
        
    }

    public void RandomMaterial()
    {
        List<TrashMaterial> availableMaterials = new List<TrashMaterial>
        {
            TrashMaterial.General,
            TrashMaterial.Plastic,
            TrashMaterial.Metal,
            TrashMaterial.Paper
        };

        List<TrashMaterial> selectedMaterials = new List<TrashMaterial>();

        for (int i = 0; i < colorButtons.Length; i++)
        {
            int randomIndex = Random.Range(0, availableMaterials.Count);
            TrashMaterial selectedMaterial = availableMaterials[randomIndex];

            colorButtons[i].GetComponent<TrashCheck>().pipeMaterial = selectedMaterial;
            materialImage[i].GetComponent<Image>().sprite = materialSprite[(int)selectedMaterial];

            selectedMaterials.Add(selectedMaterial);

            availableMaterials.RemoveAt(randomIndex);
        }
    }

    public void MaterialButton(int pipeIndex)
    {
        if (Spawn.instance.trashList.Count > 0 && Spawn.instance.click == true)
        {
            StageManager.instance.TrashDown();
            if (colorButtons[pipeIndex].GetComponent<TrashCheck>().pipeMaterial == Spawn.instance.trashList[0].GetComponent<Trash>().data.Material)
            {
                ScoreManager.instance.Yes();
            }
            else
            {
                ScoreManager.instance.No();
            }
            StartCoroutine(Spawn.instance.ColorButton(colorButtons[pipeIndex].transform));
        }

    }

    public void ResycleButton()
    {
        
    }

    public void DesytoyButton()
    {

    }
}
