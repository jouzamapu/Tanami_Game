using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InsectsState : MonoBehaviour
{
    public float insectLeft = 5; 

    public GameObject insect1;
    public GameObject insect2;
    public GameObject insect3;
    public GameObject insect4;
    public GameObject insect5;

    void Start()
    {
        
    }

    void Update()
    {
        if (insectLeft == 4)
        {
            insect5.SetActive(false);
        }
        else if (insectLeft == 3)
        {
            insect4.SetActive(false);
        }
        else if (insectLeft == 2)
        {
            insect3.SetActive(false);
        }
        else if (insectLeft == 1)
        {
            insect2.SetActive(false);
        }
        else if (insectLeft == 0)
        {
            insect1.SetActive(false);
        }

    }
}
