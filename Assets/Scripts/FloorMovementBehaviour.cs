using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorMovementBehaviour : MonoBehaviour
{
    [SerializeField]
    private GameObject floorObject;
    [SerializeField]
    public GameObject cameraObject;

    void Awake(){
        floorObject = this.gameObject;
        cameraObject = GameObject.Find("Main Camera");
    }

    void FixedUpdate(){
        MoveToForward();
    }

    void MoveToForward(){
        floorObject.transform.position = new Vector3(cameraObject.transform.position.x,0,0); 
    }
}
