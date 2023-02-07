using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlantGrow : MonoBehaviour
{
    public float plantGrowStates = 0;

    [SerializeField] Sprite plant1;
    [SerializeField] Sprite plant2;
    [SerializeField] Sprite plant3;
    [SerializeField] Sprite plant4;
    [SerializeField] Sprite plant5;
    [SerializeField] Sprite plant6;
    [SerializeField] Sprite plant7;

    [SerializeField] GameObject finishPlant;
    [SerializeField] GameObject finishPlant2;

    Image plantImage;

    // Start is called before the first frame update
    void Start()
    {
        plantImage = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (plantGrowStates == 1)
        {
            plantImage.sprite = plant1;
        }
        else if (plantGrowStates == 2)
        {
            plantImage.sprite = plant2;
        }
        else if (plantGrowStates == 3)
        {
            plantImage.sprite = plant3;
        }
        else if (plantGrowStates == 4)
        {
            plantImage.sprite = plant4;
        }
        else if (plantGrowStates == 5)
        {
            finishPlant.SetActive(true);
            plantImage.sprite = plant6;
        }
        else if (plantGrowStates == 6)
        {
            gameObject.SetActive(false);
            finishPlant2.SetActive(true);
        }
    }
}
