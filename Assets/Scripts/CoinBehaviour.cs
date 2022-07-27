using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehaviour : MonoBehaviour
{
    [SerializeField]
    private Coin coin;
    
    void Start()
    {
        coin = GetComponent<Coin>();
    }

    public void DestroyCoin(){
        Destroy(this.gameObject);
    }

    public Coin getCoin(){
        return coin;
    }
}
