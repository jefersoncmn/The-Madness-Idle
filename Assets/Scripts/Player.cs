using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float playerSpeed = 2.0f; 
    [SerializeField]
    private float playerwithBoostSpeed = 5.0f;
    private Gold gold;


    public float getPlayerSpeed(){
        return playerSpeed;
    }

    public float getPlayerBoostSpeed(){
        return playerwithBoostSpeed;
    }
}
