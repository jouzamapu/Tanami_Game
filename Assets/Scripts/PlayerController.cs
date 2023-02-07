using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject miniGames;
    [SerializeField] GameObject waterButton;
    [SerializeField] GameObject shopComponent;
    [SerializeField] GameObject potionButton;
    [SerializeField] GameObject waterEffect;
    [SerializeField] GameObject attackEffect;
    [SerializeField] VideoClip morningBackground;
    [SerializeField] VideoClip eveningBackground;
    [SerializeField] TextMeshProUGUI numberOfPotion;
    [SerializeField] int waterEffectDuration = 2;
    [SerializeField] int attactEffectDuration = 2;

    PlantGrow plantGrow;
    InsectsState insectsState;
    Timer timerCount;
    VideoPlayer backgroundControl;

    public int waterButtonCooldownDuration = 20;
    public int attackButtonCooldownDuration = 20;
    public bool waterCanPress;
    public bool attackCanPress;
    public bool canBuy;
    public bool canUsePotion;

    int potion = 0;
    int changeClicked = 0;

    void Start()
    {
        plantGrow = GetComponent<PlantGrow>();
        insectsState = GetComponent<InsectsState>();
        timerCount = GetComponent<Timer>();
        backgroundControl = GameObject.Find("Background").GetComponent<VideoPlayer>();
        waterCanPress = true;
        attackCanPress = true;
        canBuy = true;
        canUsePotion = true;
    }

    void Update()
    {
        if (potion > 0)
        {
            potionButton.SetActive(true);
        }
        else
        {
            potionButton.SetActive(false);
        }

        numberOfPotion.text = "Potion: " + potion;
    }

    public void WaterButton()
    {
        if (waterCanPress)
        {
            plantGrow.plantGrowStates += 1;
            waterEffect.SetActive(true);
            waterCanPress = false;
            StartCoroutine(WaterButtonCooldown());
            StartCoroutine(WaterEffectDuration());
        }

        if (plantGrow.plantGrowStates == 6)
        {
            waterEffect.SetActive(false);
        }

        Debug.Log(plantGrow.plantGrowStates);
    }

    public void AttackButton()
    {
        if (attackCanPress)
        {
            insectsState.insectLeft -= 1;
            attackEffect.SetActive(true);
            attackCanPress = false;
            StartCoroutine(AttackButtonCooldown());
            StartCoroutine(AttactEffectDuration());
            Debug.Log(insectsState.insectLeft);   
        }

        if (insectsState.insectLeft <= 0)
        {
            timerCount.currentTime = 20;
            timerCount.count = true;
            miniGames.SetActive(false);
            waterButton.SetActive(true);
            canBuy = true;
            canUsePotion = true;
        }
    }

    IEnumerator WaterButtonCooldown()
    {
        yield return new WaitForSeconds(waterButtonCooldownDuration);
        waterCanPress = true;
    }

    IEnumerator AttackButtonCooldown()
    {
        yield return new WaitForSeconds(attackButtonCooldownDuration);
        attackCanPress = true;
    }

    IEnumerator WaterEffectDuration()
    {
        yield return new WaitForSeconds(waterEffectDuration);
        waterEffect.SetActive(false);
    }

    IEnumerator AttactEffectDuration()
    {
        yield return new WaitForSeconds(attactEffectDuration);
        attackEffect.SetActive(false);
    }

    public void PotionButton()
    {
        if (canUsePotion)
        {
            plantGrow.plantGrowStates += 1;
            potion -= 1;
        }

        Debug.Log("State = " + plantGrow.plantGrowStates);
    }


    public void ShopButton()
    {
        if (shopComponent.activeInHierarchy == true)
        {
            shopComponent.SetActive(false);
            
        }
        else if (shopComponent.activeInHierarchy == false)
        {
            shopComponent.SetActive(true);
        }
    }

    public void BuyButton()
    {
        if (canBuy && potion <= 2)
        {
            potion += 1;
        }
    }

    public void ChangeBackgroundButton()
    {
        changeClicked += 1;
        Debug.Log(changeClicked);

        if (changeClicked % 2 == 0)
        {
            backgroundControl.clip = morningBackground;
        }
        else
        {
            backgroundControl.clip = eveningBackground;
        }

        if (changeClicked == 5)
        {
            changeClicked = 0;
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
