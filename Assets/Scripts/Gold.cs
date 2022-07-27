using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour
{
    [SerializeField]
    private long quantity = 0;

    public void Addvalue(int value){
        quantity += value; 
    }

    public void Addvalue(long value){
        quantity += value; 
    }

    public void RemoveValue(long value){
        quantity -= value;  
    }

    public long GetQuantity(){
        return quantity;
    }
}
