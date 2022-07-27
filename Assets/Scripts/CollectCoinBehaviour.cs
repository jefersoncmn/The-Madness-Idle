using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//The player will had this component
public class CollectCoinBehaviour : MonoBehaviour
{
    [SerializeField]
    private GameObject playerObject;
    [SerializeField]
    public Gold gold;

    public static event Action<string> OnCollectCoin;

    void Awake(){
        // playerObject = this.gameObject;
        playerObject = GameObject.Find("Player") as GameObject;
        gold = playerObject.GetComponent<Gold>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {   
        if(collision.gameObject.tag == "Coin"){
            CollectCoin(collision);  
        }
        
    }

    void CollectCoin(Collider2D collision){
        CoinBehaviour coinBehaviour = collision.gameObject.GetComponent<CoinBehaviour>();
        gold.Addvalue(coinBehaviour.getCoin().value);
        coinBehaviour.DestroyCoin();
        OnCollectCoin(gold.GetQuantity().ToString());
    }


}
