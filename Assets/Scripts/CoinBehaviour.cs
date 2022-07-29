using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehaviour : MonoBehaviour, IPooledObject
{
    [SerializeField]
    private Coin coin;
    
    void Awake(){
        coin = GetComponent<Coin>();
    }

    public void OnObjectSpawn(){
        //This is new Start method
    }

    public void DestroyCoin(){
        this.gameObject.SetActive(false);
    }

    public Coin getCoin(){
        return coin;
    }
}
