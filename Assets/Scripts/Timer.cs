using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] GameObject miniGames;
    [SerializeField] GameObject waterButton;

    InsectsState insectsState;
    PlayerController playerController;

    public float currentTime = 0;
    float startingTime = 20f;

    public bool count;

    void Start()
    {
        insectsState = GetComponent<InsectsState>();
        playerController = GetComponent<PlayerController>();

        count = true;
        currentTime = startingTime;
    }


    void Update()
    {
        if (count)
        {
            currentTime -= 1 * Time.deltaTime;
        }

        Debug.Log(currentTime);
        
        if (currentTime <= 0)
        {
            currentTime = 0;
            if (insectsState.insectLeft <= 0)
            {
                insectsState.insectLeft = 5;
                insectsState.insect1.SetActive(true);
                insectsState.insect2.SetActive(true);
                insectsState.insect3.SetActive(true);
                insectsState.insect4.SetActive(true);
                insectsState.insect5.SetActive(true);
            }
            miniGames.SetActive(true);
            waterButton.SetActive(false);
            playerController.canBuy = false;
            playerController.canUsePotion = false;
            count = false;
        }
    }
}
