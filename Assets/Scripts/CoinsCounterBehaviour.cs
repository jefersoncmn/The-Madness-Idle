using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsCounterBehaviour : MonoBehaviour
{
    [SerializeField]
    private Text counterTextUI;
    [SerializeField]
    private Gold playerGold;


    void Awake()
    {
        counterTextUI = GameObject.Find("CoinsCounterUI").GetComponent<Text>();
        playerGold = GameObject.Find("Player").GetComponent<Gold>();

        CollectCoinBehaviour.OnCollectCoin += ChangeCoinCounterValue;
    }

    void Start(){
        ChangeCoinCounterValue(playerGold.GetQuantity().ToString());
    }

    void ChangeCoinCounterValue(string value){
        counterTextUI.text = value;
    }
}
